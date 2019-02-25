using Challenge.Api.Models.Commons;

namespace Challenge.Api.Models.Domain
{
    public class Location : IEntity
    {
        public virtual int Id { get; set; }

        public virtual string State { get; set; }

        public virtual string Street { get; set; }

        public virtual string City { get; set; }

        public virtual string PostCode { get; set; }

        public virtual User User { get; set; }
    }
}