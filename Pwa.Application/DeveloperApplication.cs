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
        private readonly IUserRepository _user;
        private readonly IFileUploader _file;
        private readonly ISmsService _sms;
        private readonly UserManager<User> _userManager;
        //private readonly SignInManager<Developer> _signInManager;
        public DeveloperApplication(IDeveloperRepository developer,
            UserManager<User> userManager,
            //SignInManager<Developer> signInManager,
            IFileUploader file,
            ISmsService sms,
            IUserRepository user)
        {
            _userManager = userManager;
            _developer = developer;
            // _signInManager = signInManager;
            _file = file;
            _sms = sms;
            _user = user;
        }

        public async Task<List<DeveloperDto>> ListAsync()
        {
            var developer = _developer.TableNoTracking.Where(_ => (RoleStatusDto)_.User.RoleStatus == RoleStatusDto.Developer).Include(_ => _.User).Select(_ => new DeveloperDto
            {
                Id = _.Id,
                FullName = _.User.FullName,
                Email = _.User.Email,
                PhoneNumber = _.User.PhoneNumber,
                NationalCode = _.NationalCode,
                Status = (StatusDto)_.Status,
                Role = (RoleStatusDto)_.User.RoleStatus,
                CreationDate = _.CreationDate.ToFarsiFull(),
            });

            return await developer.ToListAsync();
        }

        public async Task<OperationResult<EditDeveloperDto>> Get(int id)
        {
            var developer = await _developer.TableNoTracking.Include(_ => _.User).FirstOrDefaultAsync(_ => _.Id == id);
            if (developer is null)
            {
                EditDeveloperDto nullEditDeveloperDto = new();
                return new OperationResult<EditDeveloperDto>(nullEditDeveloperDto, false, "توسعه دهنده ای با این مشخصات وجود ندارد");
            }
            EditDeveloperDto data = new()
            {
                Id = developer.Id,
                FullName = developer.User.FullName,
                NationalCode = developer.NationalCode,
                City = developer.City,
                Province = developer.Province,
                Country = developer.Country,
                //ProfileUrl = developer.ProfileUrl,
            };
            return new OperationResult<EditDeveloperDto>(data, true, "");
        }

        public async Task<OperationResult> Register(CreateDeveloperDto register, CancellationToken cancellationToken)
        {
            if (await _developer.TableNoTracking.Include(_ => _.User).AnyAsync(_ => _.User.Email == register.Email || _.User.PhoneNumber == register.PhoneNumber))
                return new OperationResult(false, "توسعه دهنده ای با این مشخصات وجود دارد");

            var profileUrl = await _file.Upload(register.ProfileUrl, UploadPath.Developer);

            User user = new(register.Email, register.UserName, register.PhoneNumber, register.FullName);
            user.SetRoleStatus(RoleStatus.Developer);

            var code = RandomGenerator.Generate();
            user.SmsCode(code);
            //await _sms.Send("09106692003", $"کد فعال سازی داریا : {code}");

            var userResult = await _userManager.CreateAsync(user, register.Password);
            if (userResult.Succeeded is false)
                return new OperationResult(true, "ثبت نام توسعه دهنده با مشکل مواجه شد");

            var roleResult = await _userManager.AddToRoleAsync(user, user.RoleStatus.ToString());
            if (roleResult.Succeeded is false)
                return new OperationResult(false, "ثبت نام توسعه دهنده با مشکل مواجه شد");

            Developer developer = new(user.Id, register.NationalCode, register.City, register.Province, register.Country, profileUrl);
            await _developer.AddAsync(developer, cancellationToken);
            await _developer.SaveChangesAsync();
            return new OperationResult(true/*, result.Errors.Select(_ => _.Description).ToString()*/);
        }

        public async Task<OperationResult> Edit(EditDeveloperDto edit)
        {
            var developer = await _developer.Table.Include(_ => _.User).FirstOrDefaultAsync(_ => _.Id == edit.Id);

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
            //var developer = await _developer.GetByIdAsync(CancellationToken.None, id);
            //developer.Active();
            await _developer.SaveChangesAsync();
        }

        public async Task DeActivate(int id)
        {
            //var developer = await _developer.GetByIdAsync(CancellationToken.None, id);
            //developer.DeActive();
            await _developer.SaveChangesAsync();
        }

        public async Task<OperationResult> VerifyBySms(string code)
        {
            // get user
            //var developer = await _userManager.GetUserAsync(_signInManager.Context.User);
            //if (developer is null)
            //    return new OperationResult(false, "توسعه دهنده ای برای تایید اس ام اس وجود ندارد");

            ////check user code with parameter code
            //if (developer.Code.Equals(code))
            //{
            //    await Activate(developer.Id);
            //    await _developer.SaveChangesAsync();
            //}

            return new OperationResult();
        }

        public async Task<OperationResult<DeveloperDto>> Detail(int id)
        {
            var developer = await _developer.TableNoTracking.Include(_ => _.User).FirstOrDefaultAsync(_ => _.Id == id);
            if (developer is null)
            {
                DeveloperDto nullDeveloperDto = new();
                return new OperationResult<DeveloperDto>(nullDeveloperDto, false, "توسعه دهنده ای با این مشخصات وجود ندارد");
            }
            DeveloperDto data = new()
            {
                Id = developer.Id,
                FullName = developer.User.FullName,
                NationalCode = developer.NationalCode,
                Email = developer.User.Email,
                PhoneNumber = developer.User.PhoneNumber,
                Status = (StatusDto)developer.Status,
                UserName = developer.User.UserName,
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
