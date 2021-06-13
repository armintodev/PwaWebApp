using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Pwa.Application.Contracts.Product.Category;
using Pwa.Application.Contracts.Product.Picture;
using Pwa.Application.Contracts.Product.WebApplication;
using Pwa.Domain.Product;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using WebFramework.Enums;
using WebFramework.Infrastructure;
using WebFramework.Utilities;
using WebFramework.Utilities.Uploader;

namespace Pwa.Application
{
    public class WebApplicationApplication : IWebApplicationApplication
    {
        private readonly IWebApplicationRepository _webRepository;
        private readonly IPictureRepository _pictureRepository;
        private readonly IFileUploader _file;
        private readonly IHttpContextAccessor _accessor;
        public WebApplicationApplication(IWebApplicationRepository webApplication,
            IFileUploader file,
            IPictureRepository pictureRepository,
            IHttpContextAccessor accessor)
        {
            _webRepository = webApplication;
            _file = file;
            _pictureRepository = pictureRepository;
            _accessor = accessor;
        }

        public async Task<List<WebApplicationDto>> List()
        {
            var webApps = _webRepository.TableNoTracking.Select(_ => new WebApplicationDto
            {
                Id = _.Id,
                Name = _.Name,
                Description = _.Description,
                WebSiteAddress = _.WebSiteAddress,
                Icon = _.Icon,
                TypeAdd = (TypeAddDto)_.TypeAdd,
                Status = (StatusDto)_.Status,
                Visit = _.Visit,
                Installed = _.Visit,
                CreationDate = _.CreationDate.ToFarsiFull()
            });

            return await webApps.ToListAsync();
        }

        public async Task<OperationResult> Create(CreateWebApplicationDto dto)
        {
            if (dto is null)
                return new OperationResult(false);

            if (await _webRepository.IsExistsAsync(_ => _.WebSiteAddress == dto.WebSiteAddress))
                return new OperationResult(false, "سایتی با این مشخصات وجود دارد");

            //developer id
            //var developerId = _accessor.HttpContext.User.Claims.FirstOrDefault(_ => _.Type == ClaimTypes.NameIdentifier).Value;
            var developerId = 1;

            if (dto.CategoryId is 0)
                return new OperationResult(false, "دسته بندی را انتخاب کنید");

            //check website for he has pwa website
            var check = await PwaCheck.Check(dto.WebSiteAddress);
            if (check is false)
                return new OperationResult(false, "سایت شما وب اپلیکیشن نمی باشد");

            var icon = await _file.Upload(dto.Icon, UploadPath.WebApplicationIcon);

            WebApplication webApp = new(dto.Name, dto.Description, dto.WebSiteAddress, icon, dto.IsGame, (TypeAdd)dto.TypeAdd, (Status)dto.Status, dto.CategoryId, developerId);
            await _webRepository.AddAsync(webApp, CancellationToken.None);

            List<Picture> pictures = new();
            foreach (var _ in dto.Files)
            {
                var url = await _file.Upload(_, UploadPath.WebApplication);
                pictures.Add(new Picture(url, webApp.Id));
            }

            await _pictureRepository.AddRangeAsync(pictures, CancellationToken.None);

            await _webRepository.SaveChangesAsync();
            return new OperationResult();
        }

        public async Task<OperationResult<EditWebApplicationDto>> Get(int id)
        {
            var webApp = await _webRepository.GetByIdAsync(CancellationToken.None, id);
            if (webApp is null)
            {
                EditWebApplicationDto nullEditWebApplicationDto = new();
                return new OperationResult<EditWebApplicationDto>(nullEditWebApplicationDto, false, "وب اپلیکیشنی با این مشخصات وجود ندارد");
            }

            EditWebApplicationDto data = new()
            {
                Id = webApp.Id,
                Name = webApp.Name,
                Description = webApp.Description,
                Status = (StatusDto)webApp.Status
            };
            return new OperationResult<EditWebApplicationDto>(data, true, "");
        }

        public async Task<OperationResult> Edit(EditWebApplicationDto dto)
        {
            var webApp = await _webRepository.GetByIdAsync(CancellationToken.None, dto.Id);

            if (await _webRepository.IsExistsAsync(_ => (_.Name == dto.Name) && _.Id != dto.Id))
            {
                return new OperationResult(false, "وب اپلیکیشنی با این عنوان وجود دارد");
            }

            string icon = "";
            if (dto.Icon is not null)
            {
                _file.Delete(webApp.Icon);
                icon = await _file.Upload(dto.Icon, UploadPath.WebApplicationIcon);
            }
            if (dto.Files is not null)
            {
                var oldPictures = await _pictureRepository.Table.Where(_ => _.WebApplicationId == webApp.Id).ToListAsync();

                await _pictureRepository.DeleteRangeAsync(oldPictures, CancellationToken.None, false);

                foreach (var _ in oldPictures)
                {
                    _file.Delete(_.FileName);
                }

                List<Picture> newPictures = new();
                foreach (var _ in dto.Files)
                {
                    var url = await _file.Upload(_, UploadPath.WebApplication);
                    newPictures.Add(new Picture(url, webApp.Id));
                }

                await _pictureRepository.AddRangeAsync(newPictures, CancellationToken.None);
            }

            webApp.Edit(dto.Name, dto.Description, icon);
            await _webRepository.SaveChangesAsync();
            return new OperationResult(true, "عملیات ویرایش با موفقیت انجام شد");
        }

        public async Task<OperationResult<WebApplicationDto>> Detail(int id)
        {
            var webApp = await _webRepository.Table.Include(_ => _.Category).FirstOrDefaultAsync(_ => _.Id == id);
            if (webApp is null)
            {
                WebApplicationDto nullWebAppDto = new();
                return new OperationResult<WebApplicationDto>(nullWebAppDto, false, "توسعه دهنده ای با این مشخصات وجود ندارد");
            }

            var pictures = await _pictureRepository.TableNoTracking.Where(_ => _.WebApplicationId == webApp.Id).ToListAsync();
            List<PictureDto> pics = new();
            foreach (var _ in pictures)
            {
                pics.Add(new PictureDto()
                {
                    PictureName = _.FileName,
                    CreationDate = _.CreationDate.ToFarsiFull()
                });
            }

            WebApplicationDto data = new()
            {
                Id = webApp.Id,
                Name = webApp.Name,
                Description = webApp.Description,
                WebSiteAddress = webApp.WebSiteAddress,
                CategoryTitle = webApp.Category.Title,
                Pictures = pics,
                Icon = webApp.Icon,
                Installed = webApp.Installed,
                Visit = webApp.Visit,
                IsGame = webApp.IsGame,
                Status = (StatusDto)webApp.Status,
                TypeAdd = (TypeAddDto)webApp.TypeAdd,
                CreationDate = webApp.CreationDate.ToFarsiFull(),
                LastEditDate = webApp.LastEditDate.ToFarsiFull()
            };
            return new OperationResult<WebApplicationDto>(data);
        }

        public async Task<OperationResult> Delete(int id)
        {
            var webApp = await _webRepository.GetByIdAsync(CancellationToken.None, id);
            var oldPictures = await _pictureRepository.Table.Where(_ => _.WebApplicationId == webApp.Id).ToListAsync();

            _file.Delete(webApp.Icon);
            foreach (var _ in oldPictures)
            {
                _file.Delete(_.FileName);
            }

            await _webRepository.DeleteAsync(webApp, CancellationToken.None);
            return new OperationResult(message: "توسعه دهنده با موفقیت حذف شد");
        }
    }
}
