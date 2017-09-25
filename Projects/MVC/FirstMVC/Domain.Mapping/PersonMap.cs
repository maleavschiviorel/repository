using Domain.Domain;
using FluentNHibernate.Mapping;

namespace Domain.Mapping
{
    public class PersonMap : ClassMap<Person>
    {
        public PersonMap()
        {
            Id(x => x.Id);
            Map(x => x.FirstName);
            Map(x => x.LastName);
            Map(x => x.BirthDate);
           
        }
    }
}