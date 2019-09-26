using System.Collections.Generic;

namespace FullStackExercise.Data.Model
{
    public class Customer
    {
        public Customer()
        {
            SalesOrderHeader = new HashSet<SalesOrderHeader>();
        }

        public int CustomerId { get; set; }
        public int? PersonId { get; set; }

        public string AccountNumber { get; set; }

        public Person Person { get; set; }
        public ICollection<SalesOrderHeader> SalesOrderHeader { get; set; }
    }
}
