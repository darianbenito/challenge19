using Challenge.Domain.Users;
using FluentNHibernate.Mapping;

namespace Challenge.Persistence.Users.NHibertante.Mappers
{
    public class LocationMapper : ClassMap<Location>
    {
        public LocationMapper()
        {
            Table("Locations");
            LazyLoad();

            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.State);
            Map(x => x.Street);
            Map(x => x.City);
            Map(x => x.PostCode);
            References(x => x.User)
                .Unique();
        }
    }
}
