using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Windows.Controls;

namespace DatabaseExample
{
    public class DataAccess
    {
        public List<Person> GetPeople(string lastName)
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("DEMO2DB")))
            {
                return connection.Query<Person>("dbo.People_GetByLastName @LastName", new { LastName = lastName }).ToList();
            }
        }

        public void InsertPerson(string lastName, string firstName, string email, string phoneNumber)
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("DEMO2DB")))
            {
                List<Person> people = new List<Person>();
                people.Add(new Person { LastName = lastName, FirstName = firstName, EmailAddress = email, PhoneNumber = phoneNumber });
                connection.Execute("dbo.People_Insert @FirstName, @LastName, @EmailAddress, @PhoneNumber", people);
            }
        }

        public void UpdatePerson(int Id, string lastName, string firstName, string email, string phoneNumber)
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("DEMO2DB")))
            {
                List<Person> people = new List<Person>();
                people.Add(new Person { id = Id, LastName = lastName, FirstName = firstName, EmailAddress = email, PhoneNumber = phoneNumber });
                connection.Execute("dbo.People_Update @Id, @FirstName, @LastName, @EmailAddress, @PhoneNumber", people);
            }
        }
    }
}
