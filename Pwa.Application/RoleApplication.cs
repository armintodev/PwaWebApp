using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Pwa.Application.Contracts.Account.Role;
using Pwa.Domain.Account;
using WebFramework.Infrastructure;
using WebFramework.Utilities;

namespace Pwa.Application
{
    public class RoleApplication : IRoleApplication
    {
        private readonly IRoleRepository _role;
        private readonly RoleManager<Role> _roleManager;
        public RoleApplication(IRoleRepository role,
         RoleManager<Role> roleManager)
        {
            _role = role;
            _roleManager = roleManager;
        }

        public async Task<OperationResult> Create(CreateRoleDto dto, CancellationToken cancellationToken)
        {
            if (await _role.IsExistsAsync(_ => _.Name == dto.Name || _.DisplayName == dto.DisplayName))
                return new OperationResult(false, "نقشی با این نام وجود دارد");

            Role role = new(dto.Name, dto.DisplayName);
            await _roleManager.CreateAsync(role);
            return new OperationResult();
        }

        public async Task<OperationResult> Delete(int id, CancellationToken cancellationToken)
        {
            var role = await _role.GetByIdAsync(cancellationToken, id);

            await _role.DeleteAsync(role, cancellationToken);
            return new OperationResult(message: "نقش با موفقیت حذف شد");
        }

        public async Task<OperationResult<RoleDto>> Detail(int id, CancellationToken cancellationToken)
        {
            var role = await _role.GetByIdAsync(cancellationToken, id);
            if (role is null)
            {
                RoleDto nullRoleDto = new();
                return new OperationResult<RoleDto>(nullRoleDto, false, "نقشی با این مشخصات وجود ندارد");
            }
            RoleDto data = new()
            {
                Id = role.Id,
                Name = role.Name,
                DisplayName = role.DisplayName,
                CreationDate = role.CreationDate.ToFarsiFull(),
                LastEditDate = role.LastEditDate.ToFarsiFull(),
            };
            return new OperationResult<RoleDto>(data);
        }

        public async Task<OperationResult> Edit(EditRoleDto dto, CancellationToken cancellationToken)
        {
            var role = await _role.GetByIdAsync(cancellationToken, dto.Id);

            if (await _role.IsExistsAsync(_ => (_.Name == dto.Name || _.DisplayName == dto.DisplayName) && _.Id != dto.Id))
            {
                return new OperationResult(false, "نقشی با این عنوان وجود دارد");
            }

            role.Edit(dto.Name, dto.DisplayName);
            await _role.SaveChangesAsync();
            return new OperationResult(true, "عملیات ویرایش با موفقیت انجام شد");
        }

        public async Task<OperationResult<EditRoleDto>> Get(int id, CancellationToken cancellationToken)
        {
            var role = await _role.GetByIdAsync(cancellationToken, id);
            if (role is null)
            {
                EditRoleDto nullEditRoleDto = new();
                return new OperationResult<EditRoleDto>(nullEditRoleDto, false, "نقشی با این مشخصات وجود ندارد");
            }
            EditRoleDto data = new()
            {
                Id = role.Id,
                Name = role.Name,
                DisplayName = role.DisplayName
            };
            return new OperationResult<EditRoleDto>(data, true, "");
        }

        public async Task<List<RoleDto>> List()
        {
            var roles = _role.TableNoTracking.Select(_ => new RoleDto()
            {
                Id = _.Id,
                Name = _.Name,
                DisplayName = _.DisplayName,
                CreationDate = _.CreationDate.ToFarsiFull(),
                LastEditDate = _.CreationDate.ToFarsiFull(),
            });

            return await roles.ToListAsync();
        }
    }
}
