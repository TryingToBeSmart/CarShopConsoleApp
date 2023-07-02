using CarClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CarShopConsoleApp
{
    class Program
    {
        static Store CarStore = new Store();
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the car store.  Create some cars and put them into the store inventory.  Then add cars to the cart.  Finally, checkout.");
            int action = chooseAction();
            while (action != 0)
            {
                switch (action)
                {
                    case 1:
                        Console.WriteLine("Add a new car:");
                        string carMake = "";
                        string carModel = "";
                        decimal carPrice = -1;
                        int carEngineSize = -1;
                        int carMileage = -1;

                        //loop until correct input
                        while (carMake == "")
                        {
                            Console.WriteLine("What is the car make? ");
                            carMake = Console.ReadLine();
                        }

                        //loop until correct input
                        while (carModel == "")
                        {
                            Console.WriteLine("What is the car model? ");
                            carModel = Console.ReadLine();

                        }

                        //loop until correct input
                        while (carPrice == -1)
                        {
                            try
                            {
                                Console.WriteLine("What is the car price? (numbers only)");
                                carPrice = int.Parse(Console.ReadLine());
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("incorrect input");
                                carPrice = -1;
                            }
                        }

                        //loop until correct input
                        while (carEngineSize != 4 && carEngineSize != 6 && carEngineSize != 8 && carEngineSize != 10)
                        {
                            try
                            {
                                Console.WriteLine("What is the car engine size? (4, 6, 8, or 10)");
                                carEngineSize = int.Parse(Console.ReadLine());
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("incorrect input");
                                carEngineSize = -1;
                            }
                        }

                        //loop until correct input
                        while (carMileage == -1)
                        {
                            try
                            {
                                Console.WriteLine("What is the car mileage? (numbers only)");
                                carMileage = int.Parse(Console.ReadLine());
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("incorrect input");
                                carMileage = -1;
                            }
                        }

                        ////create a new car object and add it to the list
                        //Car newCar = new Car();
                        //newCar.Make = carMake;
                        //newCar.Model = carModel;
                        //newCar.Price = carPrice;
                        //newCar.EngineSize = carEngineSize;
                        //newCar.Mileage = carMileage;
                        //CarStore.CarList.Add(newCar);

                        //made it simpler
                        CarStore.CarList.Add(new Car(carMake, carModel, carPrice, carEngineSize, carMileage));
                        printStoreInventory(CarStore);
                        break;

                    case 2:
                        //buy a car

                        //if empty
                        if (CarStore.CarList.Count == 0)
                        {
                            Console.WriteLine("Inventory Empty");
                            break;
                        }
                        printStoreInventory(CarStore);
                        Console.WriteLine("Which car number? (enter negative number to cancel) ");
                        int choice = int.MaxValue;
                        //loop until correct input or negative number to cancel
                        while (choice == int.MaxValue)
                        {
                            try
                            {
                                choice = int.Parse(Console.ReadLine());

                                //if negative number, then break
                                if (choice < 0) break;

                                //add car to cart
                                CarStore.ShoppingList.Add(CarStore.CarList[choice]);
                                printShoppingCart(CarStore);
                            }
                            catch (Exception)
                            {
                                //incorrect input
                                Console.WriteLine("Incorrect choice");
                                goto case 2;
                            }
                        }

                        break;

                    case 3:
                        //if empty
                        if (CarStore.ShoppingList.Count == 0)
                        {
                            Console.WriteLine("Cart Empty");
                            break;
                        }

                        //checkout
                        printShoppingCart(CarStore);
                        Console.WriteLine("Total cost: ${0}", CarStore.checkout());
                        Console.WriteLine("Thank you for your purchase!");

                        break;

                    default:
                        break;
                }
                action = chooseAction();
            }
        }

        static public int chooseAction()
        {
            int choice = -1;

            while (choice == -1)
            {
                try
                {
                    //create space
                    Console.WriteLine();
                    Console.Write("Choose an action: 0 to quit, 1 to add a car, 2 to add item to cart, 3 to checkout ");
                    choice = int.Parse(Console.ReadLine());
                    if (choice >= 0 && choice <= 3) return choice;

                    //else loop again until correct input is entered
                    else
                    {
                        Console.WriteLine("Incorrect input");
                        choice = -1;
                    }
                }
                catch (Exception)
                {
                    //loop again until correct input is entered
                    Console.WriteLine("Incorrect input");
                    choice = -1;
                } 
            }
            return choice;
        }

        static public void printStoreInventory(Store carStore)
        {
            //add space
            Console.WriteLine();
            Console.WriteLine("Inventory");
            int i = 0;
            foreach (var item in carStore.CarList)
            {
                Console.WriteLine(String.Format("Car # = {0} {1} ", i, item.Display));
                i++;
            }
        }

        static public void printShoppingCart(Store carStore)
        {
            //add space
            Console.WriteLine();
            Console.WriteLine("Shopping Cart");
            int i = 0;
            foreach (var item in carStore.ShoppingList)
            {
                Console.WriteLine(String.Format("Car # = {0} {1}", i, item.Display));
                i++;
            }
        }
    }
}