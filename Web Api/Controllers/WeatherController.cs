using Data;
using Data.Models;
using Data.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Web_Api.Controllers
{
    [Route("weather")]
    [ApiController]
    public class WeatherController
    {
        private readonly IRepository<CurrentWeather> weathers;

        public WeatherController(IRepository<CurrentWeather> weathers)
        {
            this.weathers = weathers;
        }

        [HttpGet]
        public IEnumerable<CurrentWeather> Get()
        {
            return weathers.All;
        }

        [HttpGet("{id}")]
        public ActionResult<CurrentWeather> Get(int id)
        {
            return weathers.FindById(id);
        }
        [HttpPost]
        public void Post([FromQuery] CurrentWeather value)
        {
            weathers.Update(value);
        }
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] CurrentWeather value)
        {
            weathers.Add(value);
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var entity = weathers.FindById(id);
            weathers.Delete(entity);
        }
    }
}
