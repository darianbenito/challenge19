using System;
using Domain.Commons;

namespace Domain.Users
{
    public class User : IEntity
    {
        public virtual int Id { get; set; }

        public virtual string IdValue { get; set; }

        public virtual string Gender { get; set; }

        public virtual string Name { get; set; }

        public virtual string Email { get; set; }

        public virtual DateTime BirthDate { get; set; }

        public virtual string Uuid { get; set; }

        public virtual string UserName { get; set; }

        public virtual Location Location { get; set; }

        public virtual bool IsTheOldest { get; set; }
    }
}