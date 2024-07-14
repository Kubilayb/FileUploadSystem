using Core.DataAccess;
using System;

namespace FileUploadSystem.Domain.Entities
{
    public class User : Entity<Guid>
    {
        public string UserName { get; private set; }
        public string Email { get; private set; }

        public User() : base()
        {
        }

        public User(Guid id, string userName, string email) : base(id)
        {
            UserName = userName;
            Email = email;
        }
    }
}
