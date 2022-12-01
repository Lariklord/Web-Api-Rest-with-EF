using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class CurrentWeather
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public float Temp { get; set; }
        public float MinTemp { get; set; }
        public float MaxTemp { get; set; }
    }
}
