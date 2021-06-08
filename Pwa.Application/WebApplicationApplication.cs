using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
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

            WebApplication webApp = new(dto.Name, dto.Description, dto.WebSiteAddress, (TypeAdd)dto.TypeAdd, (Status)dto.Status, dto.CategoryId, developerId);
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
    }
}
