using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Pwa.Application.Contracts.Account.Developer;
using Pwa.Domain.Account;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WebFramework.Enums;
using WebFramework.Infrastructure;

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
                    AddressId = _.AddressId,
                    StatisticId = _.StatisticId
                });
            }

            return list;
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
            //Developer developer = DeveloperExpression
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
