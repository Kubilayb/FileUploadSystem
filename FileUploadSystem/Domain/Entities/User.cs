using Core.DataAccess;
using Core.Entities;
using System;

namespace FileUploadSystem.Domain.Entities
{
    public class User : BaseUser
    {
        public string UserName { get; private set; }
        public string Email { get; private set; }

    }
}
