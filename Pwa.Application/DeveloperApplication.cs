using Microsoft.AspNetCore.Identity;
using Pwa.Application.Contracts.Account.Developer;
using Pwa.Domain.Account;
using System.Threading;
using System.Threading.Tasks;

namespace Pwa.Application
{
    public class DeveloperApplication : IDeveloperApplication
    {
        private readonly IDeveloperRepository _developer;
        private readonly UserManager<Developer> _userManager;
        private readonly SignInManager<Developer> _signInManager;
        public DeveloperApplication(IDeveloperRepository developer,
            UserManager<Developer> userManager,
            SignInManager<Developer> signInManager)
        {
            _userManager = userManager;
            _developer = developer;
            _signInManager = signInManager;
        }

        public async Task Login(CreateDeveloperDto login)
        {
            var developer = await _developer.GetByEmail(login.Email);
            if (developer is null) { }

            await _signInManager.PasswordSignInAsync(developer, login.Password, false, false);

            //await _signInManager.SignInAsync(developer, false);
        }

        public async Task Register(CreateDeveloperDto register)
        {
            //add statistic developer
            //add address location

            if (await _developer.IsExistsAsync(_ => _.PhoneNumber == register.PhoneNumber || _.Email == register.Email)) { }

            //maybe i using just email and password to register
            Developer developer = new(register.Email, register.FullName, register.NationalCode, register.PhoneNumber, 0, 0);
            await _userManager.CreateAsync(developer, register.Password);
        }

        public async Task Edit(EditDeveloperDto edit)
        {
            var developer = await _developer.GetByIdAsync(CancellationToken.None, edit.Id);
            if (developer is null) { }

            if (await _developer.IsExistsAsync(_ => (_.FullName == edit.FullName || _.NationalCode == edit.NationalCode) && _.Id != edit.Id)) { }

            developer.Edit(edit.FullName, edit.NationalCode);
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
