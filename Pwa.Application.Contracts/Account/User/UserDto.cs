using System;
using WebFramework.Enums;
using WebFramework.Infrastructure;

namespace Pwa.Application.Contracts.Account.User
{
    public record UserDto : IDto
    {
        public int Id { get; init; }
        public string FullName { get; init; }
        public string Email { get; init; }
        public string PhoneNumber { get; init; }
        public string Code { get; init; }
        public StatusDto Status { get; init; }
        public string CreationDate { get; init; }
    }
}
