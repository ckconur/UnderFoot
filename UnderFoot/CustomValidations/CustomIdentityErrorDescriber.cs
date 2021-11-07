using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnderFoot.CustomValidations
{
    public class CustomIdentityErrorDescriber : IdentityErrorDescriber
    {
        public override IdentityError InvalidUserName(string userName)
        {
            return new IdentityError()
            {
                Code = "InvalidUserName",
                Description = $"Bu kullanıcı adı {userName} geçersizdir."
            };
        }

        public override IdentityError DuplicateUserName(string userName)
        {
            return new IdentityError()
            {
                Code = "DublicateUserName",
                Description = $"Bu kullanıcı adı {userName} zaten kullanılmaktadır."
            };
        }

        public override IdentityError DuplicateEmail(string email)
        {
            return new IdentityError()
            {
                Code = "DublicateEmail",
                Description = $"Bu mail adresi {email} daha önce alınmıştır."
            };
        }

        public override IdentityError PasswordTooShort(int length)
        {
            return new IdentityError()
            {
                Code = "PasswordTooShort",
                Description = $"Şifre en az {length} karakterden oluşmalıdır."
            };
        }

    }
}
