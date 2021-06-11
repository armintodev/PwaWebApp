using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Pwa.Application.Contracts.Account.User;
using Pwa.Domain.Account;
using WebFramework.Enums;
using WebFramework.Infrastructure;
using WebFramework.Utilities;
using WebFramework.Utilities.Sms;

namespace Pwa.Application
{
    public class UserApplication : IUserApplication
    {
        private readonly IUserRepository _user;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ISmsService _sms;
        public UserApplication(IUserRepository user,
         SignInManager<User> signInManager,
          UserManager<User> userManager,
           ISmsService sms)
        {
            _user = user;
            _signInManager = signInManager;
            _userManager = userManager;
            _sms = sms;
        }

        public async Task Activate(int id, CancellationToken cancellationToken)
        {
            var user = await _user.GetByIdAsync(cancellationToken, id);
            user.Active();
            await _user.SaveChangesAsync();
        }

        public async Task DeActivate(int id, CancellationToken cancellationToken)
        {
            var user = await _user.GetByIdAsync(cancellationToken, id);
            user.DeActive();
            await _user.SaveChangesAsync();
        }

        public async Task<OperationResult> Delete(int id, CancellationToken cancellationToken)
        {
            var user = await _user.GetByIdAsync(cancellationToken, id);

            await _user.DeleteAsync(user, cancellationToken);
            return new OperationResult(message: "کاربر با موفقیت حذف شد");
        }

        public async Task<OperationResult<UserDto>> Detail(int id, CancellationToken cancellationToken)
        {
            var user = await _user.GetByIdAsync(cancellationToken, id);
            if (user is null)
            {
                UserDto nullUserDto = new();
                return new OperationResult<UserDto>(nullUserDto, false, "کاربری با این مشخصات وجود ندارد");
            }
            UserDto data = new()
            {
                Id = user.Id,
                FullName = user.FullName,
                Status = (StatusDto)user.Status,
                UserName = user.UserName,
                PhoneNumber = user.PhoneNumber,
                Role = (RoleStatusDto)user.RoleStatus,
                CreationDate = user.CreationDate.ToFarsiFull(),
                LastEditDate = user.LastEditDate.ToFarsiFull(),
            };
            return new OperationResult<UserDto>(data);
        }

        public async Task<OperationResult> Edit(EditUserDto dto, CancellationToken cancellationToken)
        {
            var user = await _user.GetByIdAsync(cancellationToken, dto.Id);

            if (!await _user.IsExistsAsync(_ => _.PhoneNumber == dto.PhoneNumber && _.Id == dto.Id))
            {
                return new OperationResult(false, "کاربری با این عنوان وجود دارد");
            }

            user.Edit(dto.FullName);
            await _user.SaveChangesAsync();
            return new OperationResult(true, "عملیات ویرایش با موفقیت انجام شد");
        }

        public async Task<OperationResult> Register(AuthDto dto, CancellationToken cancellationToken)
        {
            if (await _user.IsExistsAsync(_ => _.PhoneNumber == dto.PhoneNumber))
                return new OperationResult(false, "کاربری با این مشخصات وجود دارد");

            User user = new(dto.PhoneNumber, dto.FullName);

            var userResult = await _userManager.CreateAsync(user);
            if (userResult.Succeeded is false)
                return new OperationResult(false, "ثبت نام کاربر با مشکل مواجه شد");

            var roleResult = await _userManager.AddToRoleAsync(user, user.RoleStatus.ToString());
            if (roleResult.Succeeded is false)
                return new OperationResult(false, "ثبت نام کاربر با مشکل مواجه شد");

            return new OperationResult();
        }

        public async Task<List<UserDto>> List()
        {
            var users = _user.TableNoTracking.Select(_ => new UserDto()
            {
                Id = _.Id,
                UserName = _.PhoneNumber,
                Status = (StatusDto)_.Status,
                Role = (RoleStatusDto)_.RoleStatus,
                CreationDate = _.CreationDate.ToFarsiFull(),
            });

            users.Where(_ => _.Role != RoleStatusDto.Developer);

            return await users.ToListAsync();
        }

        public async Task<OperationResult<EditUserDto>> Get(int id, CancellationToken cancellationToken)
        {
            var user = await _user.GetByIdAsync(cancellationToken, id);
            if (user is null)
            {
                EditUserDto nullEditUserDto = new();
                return new OperationResult<EditUserDto>(nullEditUserDto, false, "کاربری با این مشخصات وجود ندارد");
            }
            EditUserDto data = new()
            {
                Id = user.Id,
                FullName = user.FullName,
                PhoneNumber = user.PhoneNumber
            };
            return new OperationResult<EditUserDto>(data, true, "");
        }

        public async Task<OperationResult> Login(AuthDto dto, CancellationToken cancellationToken)
        {
            if (await _user.IsExistsAsync(_ => _.PhoneNumber != dto.PhoneNumber))
            {
                return new OperationResult(false, "کاربری با این مشخصات وجود ندارد");
            }

            //send sms
            return new OperationResult();
        }

        public async Task<OperationResult> VerifyAccountBySms(SmsVerifyDto dto, CancellationToken cancellationToken)
        {
            var user = await _user.Table.FirstOrDefaultAsync(_ => _.PhoneNumber == dto.PhoneNumber, cancellationToken);
            if (user is null)
                return new OperationResult(false, "مشکلی رخ داده،لطفا دوباره امتحان کنید");

            if (user.Code == dto.Code)
                user.PhoneNumberConfirmed = true;

            else return new OperationResult(false, "کد فعال سازی اشتباه است");

            await _signInManager.SignInAsync(user, dto.RememberMe);
            user.Active();
            await _user.SaveChangesAsync();
            return new OperationResult();
        }

        public async Task<OperationResult> SendCode(string phoneNumber, CancellationToken cancellationToken)
        {
            var user = await _user.Table.FirstOrDefaultAsync(_ => _.PhoneNumber == phoneNumber, cancellationToken);
            if (user is null)
                return new OperationResult(false, "مشکلی رخ داده،لطفا دوباره امتحان کنید");

            var code = RandomGenerator.Generate();
            user.SmsCode(code);
            await _sms.Send("09106692003", $"کد فعال سازی داریا : {code}");
            await _user.SaveChangesAsync();
            return new OperationResult();
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
