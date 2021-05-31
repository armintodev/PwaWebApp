using Pwa.Application.Contracts.Account.User;
using Pwa.Domain.Account;
using System;
using System.Linq.Expressions;
using WebFramework.Enums;

namespace Pwa.Infrastructure.EfCore.Expressions
{
    public static class UserExpression
    {
        public static Expression<Func<User, UserDto>> ToDto => _ => new UserDto
        {
            Id = _.Id,
            FullName = _.FullName,
            Email = _.Email,
            PhoneNumber = _.PhoneNumber,
            Code = _.Code,
            Status = (StatusDto)_.Status,
            CreationDate = _.CreationDate.ToString(),
        };

        //to create user , maybe i use to CreateUserDto rather than UserDto
        public static Expression<Func<UserDto, User>> FromDto => _ => new User(_.PhoneNumber)
        {
            Id = _.Id,
            Email = _.Email,
            UserName = _.PhoneNumber
        };
    }
}
