using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Weable.TMS.Model.Data;

namespace Weable.TMS.BO.Web.Models
{
    public class PersonModel : BaseModel
    {
        public PersonModel()
        {

        }

        public PersonModel(Person person, IMapper mapper)
        {
            mapper.Map(person, this);
        }

        public static List<PersonModel> createModels(IList<Person> persons, IMapper mapper)
        {
            var list = new List<PersonModel>();
            foreach (Person person in persons)
                list.Add(new PersonModel(person, mapper));
            return list;
        }

        public int? PersonId { get; set; }
        public string CitizenId { get; set; }
        public string Prefix { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public int? TrainingAmount { get; set; }
    }
}
