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
            all = new List<Person>();
            customers = new List<Customer>();
            employees = new List<Employee>();

            string sql = "select * from user";
            all = db.LoadData<Person, dynamic>(sql, new { }, connection);
            last_id = all[all.Count - 1].ID;
            //Console.WriteLine(last_id);

            foreach (Person person in all)
            {
                if (person.Role_ID == 1)
                {
                    Customer customer = new Customer(person.ID, person.Role_ID, person.Name,
                        person.Email, person.Created_At, person.Address);
                    customers.Add(customer);
                }
                else
                {
                    Employee employee = new Employee(person.ID, person.Role_ID, person.Name,
                        person.Email, person.Created_At, person.Address);
                    employees.Add(employee);
                }
            }
        }
        public void viewSplit()
        {
            foreach (Customer customer in customers)
            {
                Console.WriteLine(customer + " ");
            }
            Console.WriteLine("");
            foreach (Employee employee in employees)
            {
                Console.WriteLine(employee + " ");
            }
        }
        public override void print()
        {
            foreach (Person person in all)
                Console.WriteLine(person);
        }

        public override void add(Person person)
        {
            string sql = "insert into user(role_id, name, email, address, created_at) values " +
                "(@r, @n, @e, @a, @c)";
            db.SaveData(sql, new
            {
                r = person.Role_ID,
                n = person.Name,
                e = person.Email,
                a = person.Address,
                c = person.Created_At
            }, connection);
            read();
        }
        public override void delete(int id)
        {
            Console.WriteLine(Last_ID);
            string sql = "delete from user where id = @i";
            db.SaveData(sql, new { i = id }, connection);
            read();
        }
        public Person getByName(string name)
        {
            string sql = "select * from user where name = @n limit 1";
            List<Person> people = db.LoadData<Person, dynamic>(sql, new { n = name }, connection);
            if (people.Count == 0)
                return null;
            return people[0];
        }
    }
}
