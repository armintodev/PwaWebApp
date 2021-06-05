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
using WebFramework.Utilities.Uploader;

namespace Pwa.Application
{
    public class DeveloperApplication : IDeveloperApplication
    {
        private readonly IDeveloperRepository _developer;
        private readonly IFileUploader _file;
        private readonly UserManager<Developer> _userManager;
        private readonly SignInManager<Developer> _signInManager;
        public DeveloperApplication(IDeveloperRepository developer,
            UserManager<Developer> userManager,
            SignInManager<Developer> signInManager, IFileUploader file)
        {
            _userManager = userManager;
            _developer = developer;
            _signInManager = signInManager;
            _file = file;
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

        public async Task<OperationResult> Login(LoginDto login)
        {
            var developer = await _developer.Entities.Where(_ => _.PhoneNumber == login.PhoneNumber && _.PhoneNumberConfirmed)
                .FirstOrDefaultAsync();
            if (developer is null) return new OperationResult(false, "توسعه دهنده ای با این مشخصات وجود ندارد");

            //await _signInManager.PasswordSignInAsync(developer, createDeveloper.Password, false, false);

            await _signInManager.SignInAsync(developer, false);
            return new OperationResult(false, "");
        }

        public async Task<OperationResult> Register(CreateDeveloperDto register)
        {
            if (await _developer.IsExistsAsync(_ => _.PhoneNumber == register.PhoneNumber || _.Email == register.Email))
                return new OperationResult(false, "توسعه دهنده ای با این مشخصات وجود دارد");

            const string path = "Developer";
            var profileUrl = await _file.Upload(register.ProfileUrl, path);

            //maybe i using just email and password to register
            Developer developer = new(register.Email, register.UserName, register.FullName, register.NationalCode, register.PhoneNumber, register.City, register.Province, register.Country, profileUrl);

            var result = await _userManager.CreateAsync(developer, register.Password);
            if (result.Succeeded)
                return new OperationResult(true, "عملیات با موفقیت انجام شد");

            return new OperationResult(false, result.Errors.Select(_ => _.Description).ToString());
        }

        public async Task Edit(EditDeveloperDto edit)
        {
            var developer = await _developer.GetByIdAsync(CancellationToken.None, edit.Id);
            if (developer is null) { }

            if (await _developer.IsExistsAsync(_ => (_.FullName == edit.FullName || _.NationalCode == edit.NationalCode) && _.Id != edit.Id)) { }

            var profileUrl = "";

            developer.Edit(edit.FullName, edit.NationalCode, edit.City, edit.Province, edit.Country, profileUrl);
            await _developer.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var developer = await _developer.GetByIdAsync(CancellationToken.None, id);
            if (developer is null) { }
            await _developer.DeleteAsync(developer, CancellationToken.None, true);
        }

        public async Task Activate(int id)
        {
            var developer = await _developer.GetByIdAsync(CancellationToken.None, id);
            if (developer is null) { }
            developer.Active();
            await _developer.SaveChangesAsync();
        }

        public async Task DeActivate(int id)
        {
            var developer = await _developer.GetByIdAsync(CancellationToken.None, id);
            if (developer is null) { }
            developer.DeActive();
            await _developer.SaveChangesAsync();
        }
    }
}
