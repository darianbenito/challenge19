using Challenge.Api.Models.Domain;
using FluentNHibernate.Mapping;

namespace Challenge.Api.Repositories.NHibernate.Mappers
{
    public class UserMapper : ClassMap<User>
    {
        public UserMapper()
        {
            Table("Users");
            LazyLoad();

            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.IdValue);
            Map(x => x.Gender);
            Map(x => x.Name);
            Map(x => x.Email);
            Map(x => x.BirthDate);
            Map(x => x.Uuid);
            Map(x => x.UserName);
            HasOne(x => x.Location)
                .Cascade.SaveUpdate();
        }
    }
}
