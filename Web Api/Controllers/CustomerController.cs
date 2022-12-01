using Data;
using Data.Models;
using Data.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Web_Api.Controllers
{
    [Route("/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private IRepository<Customer> customers;

        public CustomerController(IRepository<Customer> customers)
        {
           this.customers = customers;
           // IRepository<Customer> repo = IoCContainer.Resolve<IRepository<Customer>>();
           //this.customers = repo;
        }
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return customers.All;
        }

        [HttpGet("{id}")]
        public ActionResult<Customer> Get(int id)
        {
            return customers.FindById(id);
        }
        [HttpPost]
        public void Post([FromQuery] Customer value)
        {
            customers.Update(value);
        }
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Customer value)
        {
            customers.Add(value);
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var entity = customers.FindById(id);
            customers.Delete(entity);
        }
    }
}
