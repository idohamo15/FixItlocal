using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class City : BaseEntity
    {
        public string Name { get; set; }

        public City(string cityName)
        {
            Name = cityName;
        }

        public City(int id, string cityName)
        {
            Id = id;
            Name = cityName;
        }

        public int ID
        {
            get => Id;
            set => Id = value;
        }

        public City()
        {
        }
    }
}
