using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class WeatherRepository : IRepository<CurrentWeather>
    {
        private readonly WebApiContext context;

        public WeatherRepository(WebApiContext context)
        {
            this.context = context;
        }
        public IEnumerable<CurrentWeather> All => context.Weathers.ToList();

        public void Add(CurrentWeather entity)
        {
            context.Weathers.Add(entity);
        }

        public void Delete(CurrentWeather entity)
        {
            context.Weathers.Remove(entity);
            context.SaveChanges();
        }

        public CurrentWeather FindById(string id)
        {
            throw new NotImplementedException();
        }

        public CurrentWeather FindById(int id)
        {
            return context.Weathers.FirstOrDefault(x => x.Id == id)!;
        }

        public void Update(CurrentWeather entity)
        {
            context.Weathers.Update(entity);
            context.SaveChanges();
        }
    }
}
