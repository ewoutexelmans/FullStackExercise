using System;
using System.Collections.Generic;

namespace FullStackExercise.Data.Model
{
    public class Person
    {
        public Person()
        {
            Customer = new HashSet<Customer>();
        }

        public int BusinessEntityId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<Customer> Customer { get; set; }
    }
}
