using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarClassLibrary
{
    public class Store
    {
        public List<Car> CarList { get; set; }
        public List<Car> ShoppingList { get; set; }

        public Store(List<Car> carList, List<Car> shoppingList)
        {
            CarList = carList;
            ShoppingList = shoppingList;
        }

        public Store()
        {
            //initialize lists
            CarList = new List<Car>();
            ShoppingList = new List<Car>();
        }

        public decimal checkout()
        {
            decimal totalCost = 0;

            //calculate the total cost of the items in the cart
            foreach (var car in ShoppingList)
            {
                totalCost += car.Price;
            }

            //clear the shopping cart
            ShoppingList.Clear();

            // return the total
            return totalCost;
        }
    }
}
