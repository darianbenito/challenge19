using Challenge.Api.Models.Domain;
using FluentNHibernate.Mapping;

namespace Challenge.Api.Repositories.NHibernate.Mappers
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
