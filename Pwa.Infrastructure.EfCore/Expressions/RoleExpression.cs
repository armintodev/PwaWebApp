using Pwa.Application.Contracts.Account.Role;
using Pwa.Domain.Account;
using System;
using System.Linq.Expressions;

namespace Pwa.Infrastructure.EfCore.Expressions
{
    public static class RoleExpression
    {
        public static Expression<Func<Role, RoleDto>> ToDto => _ => new RoleDto
        {
            Id = _.Id,
            Name = _.Name
        };

        //to create role , maybe i use to CreateRoleDto rather than RoleDto
        public static Expression<Func<RoleDto, Role>> FromDto => _ => new Role(_.Name)
        {
            Id = _.Id
        };
    }
}
