using bank.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank.repository
{
    public class PersonRepository : Repository<Person>
    {
        List<Customer> customers = new List<Customer>();
        List<Employee> employees = new List<Employee>();

        public PersonRepository()
        {
            read();
        }

        public override void read()
        {
            string sql = "select * from user";
            all = db.LoadData<Person, dynamic>(sql, new { }, connection);
            last_id = all[all.Count - 1].ID;


            for (int i = 0; i < all.Count; i++)
            {
                if (all[i].Role_ID == 1)
                {
                    //Console.WriteLine(1);
                    Customer customer = all[i] as Customer;
                    //Console.WriteLine(all[i]);
                    customers.Add(customer);
                }
                else employees.Add(all[i] as Employee);
            }
            foreach (Person person in all)
            {
                Console.WriteLine(person.Role_ID);
                if (person.Role_ID == 1)
                {
                    Customer customer = new Customer(person.ID, person.Role_ID, person.Name,
                        person.Email, person.Created_At, person.Adress);
                    customers.Add(customer);
                }
                else
                {
                    employees.Add(person as Employee);
                }
            }
        }
        public void viewSplit()
        {
            foreach(Customer customer in customers)
            {
                Console.Write(customer + " ");
            }
            Console.WriteLine("");
            foreach(Employee employee in employees)
            {
                Console.Write(employee + " ");
            }
        }
        public override void print()
        {
            foreach (Person person in all)
                Console.WriteLine(person);
        }
        public override void add()
        {
            //throw new NotImplementedException();
        }
        public override void delete()
        {
            //throw new NotImplementedException();
        }
    }
}
