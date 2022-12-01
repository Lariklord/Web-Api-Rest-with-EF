using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class CustomerRepository:IRepository<Customer>
    {
        private readonly WebApiContext context;

        public CustomerRepository(WebApiContext context)
        {
            this.context = context;
        }
        public IEnumerable<Customer> All => context.Customers.ToList();

        public void Add(Customer entity)
        {
            context.Customers.Add(entity);
        }

        public void Delete(Customer entity)
        {
            context.Customers.Remove(entity);
            context.SaveChanges();
        }

        public Customer FindById(string id)
        {
            throw new NotImplementedException();
        }

        public Customer FindById(int id)
        {
            return context.Customers.FirstOrDefault(x => x.Id == id)!;
        }

        public void Update(Customer entity)
        {
            context.Customers.Update(entity);
            context.SaveChanges();
        }
    }
}
