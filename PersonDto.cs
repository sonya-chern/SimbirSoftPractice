using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationProject
{
    public class PersonDto
    {
        private string lastName;
        private string firstName;
        private string patronymic;
        private DateTime birthDay;
        public static List<PersonDto> listPersons = new List<PersonDto>(3);
    }

    
}
