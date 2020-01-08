﻿using System;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Test;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetCore.Identity.Dapper.Tests
{
    public class UserManagerSpecificationTests : UserManagerSpecificationTestBase<IdentityUser>
    {
        protected override void AddUserStore(IServiceCollection services, object context = null) {
            throw new NotImplementedException();
        }

        protected override object CreateTestContext() {
            return null;
        }

        protected override IdentityUser CreateTestUser(string namePrefix = "", string email = "", string phoneNumber = "", bool lockoutEnabled = false, DateTimeOffset? lockoutEnd = null, bool useNamePrefixAsUserName = false) {
            return new IdentityUser {
                UserName = useNamePrefixAsUserName ? namePrefix : $"{namePrefix}{Guid.NewGuid()}",
                Email = email,
                PhoneNumber = phoneNumber,
                LockoutEnabled = lockoutEnabled,
                LockoutEnd = lockoutEnd
            };
        }

        protected override void SetUserPasswordHash(IdentityUser user, string hashedPassword) {
            user.PasswordHash = hashedPassword;
        }

        protected override Expression<Func<IdentityUser, bool>> UserNameEqualsPredicate(string userName) {
            return user => user.UserName == userName;
        }

        protected override Expression<Func<IdentityUser, bool>> UserNameStartsWithPredicate(string userName) {
            return user => user != null && user.UserName.StartsWith(userName);
        }
    }
}
