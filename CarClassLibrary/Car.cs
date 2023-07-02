using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarClassLibrary
{
    public class Car
    {
        // properties
        public string Make { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        public int EngineSize { get; set; }
        public int Mileage { get; set; }

        public Car(string make, string model, decimal price, int engineSize, int mileage)
        {
            Make = make;
            Model = model;
            Price = price;
            EngineSize = engineSize;
            Mileage = mileage;
        }

        public Car()
        {
        }

        public string Display
        {
            get
            {
                return string.Format("{0} {1} ${2} V{3} {4}", Make, Model, Price, EngineSize, Mileage);
            }
        }
    }
}
