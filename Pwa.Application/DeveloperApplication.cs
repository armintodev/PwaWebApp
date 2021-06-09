using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Pwa.Application.Contracts.Account.Developer;
using Pwa.Domain.Account;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Pwa.Application.Contracts.Account.User;
using WebFramework.Enums;
using WebFramework.Infrastructure;
using WebFramework.Utilities;
using WebFramework.Utilities.Sms;
using WebFramework.Utilities.Uploader;

namespace Pwa.Application
{
    public class DeveloperApplication : IDeveloperApplication
    {
        private readonly IDeveloperRepository _developer;
        private readonly IFileUploader _file;
        private readonly ISmsService _sms;
        private readonly UserManager<Developer> _userManager;
        private readonly SignInManager<Developer> _signInManager;
        public DeveloperApplication(IDeveloperRepository developer,
            UserManager<Developer> userManager,
            SignInManager<Developer> signInManager, IFileUploader file, ISmsService sms)
        {
            _userManager = userManager;
            _developer = developer;
            _signInManager = signInManager;
            _file = file;
            _sms = sms;
        }

        public async Task<List<DeveloperDto>> ListAsync()
        {
            var developer = await _developer.TableNoTracking.ToListAsync();
            List<DeveloperDto> list = new();
            foreach (var _ in developer)
            {
                list.Add(new DeveloperDto
                {
                    Id = _.Id,
                    FullName = _.FullName,
                    Email = _.Email,
                    PhoneNumber = _.PhoneNumber,
                    NationalCode = _.NationalCode,
                    Code = _.Code,
                    Status = (StatusDto)_.Status,
                    CreationDate = _.CreationDate.ToFarsi(),
                });
            }

            return list;
        }

        public async Task<OperationResult<EditDeveloperDto>> Get(int id)
        {
            var developer = await _developer.GetByIdAsync(CancellationToken.None, id);
            if (developer is null)
            {
                EditDeveloperDto nullEditDeveloperDto = new();
                return new OperationResult<EditDeveloperDto>(nullEditDeveloperDto, false, "توسعه دهنده ای با این مشخصات وجود ندارد");
            }
            EditDeveloperDto data = new()
            {
                Id = developer.Id,
                FullName = developer.FullName,
                NationalCode = developer.NationalCode,
                City = developer.City,
                Province = developer.Province,
                Country = developer.Country,
                //ProfileUrl = developer.ProfileUrl,
            };
            return new OperationResult<EditDeveloperDto>(data, true, "");
        }

        public async Task<OperationResult> Register(CreateDeveloperDto register)
        {
            if (await _developer.IsExistsAsync(_ => _.PhoneNumber == register.PhoneNumber || _.Email == register.Email))
                return new OperationResult(false, "توسعه دهنده ای با این مشخصات وجود دارد");

            var profileUrl = await _file.Upload(register.ProfileUrl, UploadPath.Developer);

            //maybe i using just email and password to register
            Developer developer = new(register.Email, register.UserName, register.FullName, register.NationalCode, register.PhoneNumber, register.City, register.Province, register.Country, profileUrl);

            var code = RandomGenerator.Generate();
            developer.SmsCode(code);
            await _sms.Send("09106692003", $"کد فعال سازی داریا : {code}");

            var result = await _userManager.CreateAsync(developer, register.Password);

            if (result.Succeeded)
                return new OperationResult(true, "عملیات با موفقیت انجام شد");

            return new OperationResult(false, result.Errors.Select(_ => _.Description).ToString());
        }

        public async Task<OperationResult> Edit(EditDeveloperDto edit)
        {
            var developer = await _developer.GetByIdAsync(CancellationToken.None, edit.Id);

            if (await _developer.IsExistsAsync(_ => (_.FullName == edit.FullName || _.NationalCode == edit.NationalCode) && _.Id != edit.Id)) { }

            var profileUrl = "";
            if (edit.ProfileUrl is not null)
            {
                _file.Delete(developer.ProfileUrl);
                profileUrl = await _file.Upload(edit.ProfileUrl, UploadPath.Developer);
            }

            developer.Edit(edit.FullName, edit.NationalCode, edit.City, edit.Province, edit.Country, profileUrl);
            await _developer.SaveChangesAsync();
            return new OperationResult(true, "عملیات ویرایش با موفقیت انجام شد");
        }

        public async Task<OperationResult> Delete(int id)
        {
            var developer = await _developer.GetByIdAsync(CancellationToken.None, id);

            await _developer.DeleteAsync(developer, CancellationToken.None);
            _file.Delete(developer.ProfileUrl);
            return new OperationResult(message: "توسعه دهنده با موفقیت حذف شد");
        }

        public async Task Activate(int id)
        {
            var developer = await _developer.GetByIdAsync(CancellationToken.None, id);
            developer.Active();
            await _developer.SaveChangesAsync();
        }

        public async Task DeActivate(int id)
        {
            var developer = await _developer.GetByIdAsync(CancellationToken.None, id);
            developer.DeActive();
            await _developer.SaveChangesAsync();
        }

        public async Task<OperationResult> VerifyBySms(string code)
        {
            // get user
            var developer = await _userManager.GetUserAsync(_signInManager.Context.User);
            if (developer is null)
                return new OperationResult(false, "توسعه دهنده ای برای تایید اس ام اس وجود ندارد");

            //check user code with parameter code
            if (developer.Code.Equals(code))
            {
                await Activate(developer.Id);
                await _developer.SaveChangesAsync();
            }

            return new OperationResult();
        }

        public async Task<OperationResult<DeveloperDto>> Detail(int id)
        {
            var developer = await _developer.GetByIdAsync(CancellationToken.None, id);
            if (developer is null)
            {
                DeveloperDto nullDeveloperDto = new();
                return new OperationResult<DeveloperDto>(nullDeveloperDto, false, "توسعه دهنده ای با این مشخصات وجود ندارد");
            }
            DeveloperDto data = new()
            {
                Id = developer.Id,
                FullName = developer.FullName,
                NationalCode = developer.NationalCode,
                Email = developer.Email,
                PhoneNumber = developer.PhoneNumber,
                Status = (StatusDto)developer.Status,
                UserName = developer.UserName,
                City = developer.City,
                Province = developer.Province,
                Country = developer.Country,
                ProfileUrl = developer.ProfileUrl,
                CreationDate = developer.CreationDate.ToFarsiFull(),
                LastEditDate = developer.LastEditDate.ToFarsiFull(),
            };
            return new OperationResult<DeveloperDto>(data);
        }
    }
}
