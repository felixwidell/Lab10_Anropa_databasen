using DBFirst.Data;
using Microsoft.Extensions.Options;
using System;

namespace DBFirst
{
    internal class Program
    {
        static void Main(string[] args)
        {



            ConsoleKeyInfo keyinfo;
            int optionIndex = 0;


            do
            {
                Console.WriteLine("--Get All Customers-- press ENTER to execute");
                if (optionIndex == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Order by Companyname Alphabetiaclly");
                    Console.ResetColor();
                    Console.WriteLine("Order by Companyname Alpabetically reversed");
                }

                if (optionIndex == 1)
                {
                    Console.WriteLine("Order by Companyname Alphabetiaclly");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Order by Companyname Alpabetically reversed");
                    Console.ResetColor();
                }

                keyinfo = Console.ReadKey();

                if (keyinfo.Key == ConsoleKey.DownArrow && optionIndex < 1)
                {
                    optionIndex++;
                }
                else if (keyinfo.Key == ConsoleKey.UpArrow && optionIndex > 0)
                {
                    optionIndex--;
                }
                Console.Clear();

            } while (keyinfo.Key != ConsoleKey.Enter);





            using (var context = new NorthContext())
            {
                var emp = context.Customers
                                  .Select(e => e).ToList();

                var orders = context.Orders
                    .Select(e => e).ToList();


                if (optionIndex == 1)
                {
                    emp.Reverse();
                }


                int customerIndex = 0;


                Console.WriteLine("Use down arrow key to initialize");

                SelectCustomer(emp, orders);


                void SelectCustomer(List<Models.Customer> customers, List<Models.Order> orders)
                {
                    do
                    {
                        int listItem2 = 0;
                        keyinfo = Console.ReadKey();

                        if (keyinfo.Key == ConsoleKey.DownArrow && customerIndex <= emp.Count)
                        {
                            Console.Clear();
                            customerIndex++;
                            foreach (var customer in emp)
                            {
                                if (customerIndex == listItem2)
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine($"Company name: {customer.CompanyName} Country: {customer.Country}     Region: {customer.Region}     Phone: {customer.Phone}    Orders: {orders.Where(e => e.CustomerId == customer.CustomerId).Count()}");
                                    Console.ResetColor();
                                }
                                else
                                {
                                    Console.WriteLine($"Company name: {customer.CompanyName} Country: {customer.Country}     Region: {customer.Region}     Phone: {customer.Phone}    Orders: {orders.Where(e => e.CustomerId == customer.CustomerId).Count()}");
                                }

                                listItem2++;
                            }
                            Console.WriteLine("Customer: " + customerIndex);
                        }
                        else if (keyinfo.Key == ConsoleKey.UpArrow && customerIndex > 0)
                        {
                            Console.Clear();
                            customerIndex--;
                            foreach (var customer in emp)
                            {
                                if (customerIndex == listItem2)
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine($"Company name: {customer.CompanyName} Country: {customer.Country}     Region: {customer.Region}     Phone: {customer.Phone}");
                                    Console.ResetColor();
                                }
                                else
                                {
                                    Console.WriteLine($"Company name: {customer.CompanyName} Country: {customer.Country}     Region: {customer.Region}     Phone: {customer.Phone}");
                                }

                                listItem2++;
                            }
                            Console.WriteLine("Customer: " + customerIndex);
                        }
                    } while (Console.ReadKey().Key != ConsoleKey.Enter);

                    Console.Clear();
                    var SelectedCustomer = emp[customerIndex];
                    PrintSelectedCustomer(SelectedCustomer);

                }

                void PrintSelectedCustomer(Models.Customer SelectedCustomer)
                {
                    var Customer = context.Customers
                                       .Where(e => e.CustomerId == SelectedCustomer.CustomerId)
                                      .Select(e => e).ToList();



                    Console.WriteLine($"Companyname: {Customer[0].CompanyName} " +
                        $"\nContactname: {Customer[0].ContactName} " +
                        $"\nContacttitle: {Customer[0].ContactTitle} " +
                        $"\nAddress: {Customer[0].Address} " +
                        $"\nCity: {Customer[0].City} " +
                        $"\nRegion: {Customer[0].Region} " +
                        $"\nPostalcode: {Customer[0].PostalCode} " +
                        $"\nCountry: {Customer[0].Country}" +
                        $"\nPhone:  {Customer[0].Phone} " +
                        $"\nFax: {Customer[0].Fax} " +
                        $"\nCustomertypes: {Customer[0].CustomerTypes.Count()}\n\n");

                    var CustomerOrders = context.Orders
                                       .Where(e => e.CustomerId == Customer[0].CustomerId)
                                      .Select(e => e).ToList();

                    Console.WriteLine("-----ORDERS-----");
                    foreach (var order in CustomerOrders)
                    {
                        Console.WriteLine($"Shipname: {order.ShipName} \nShipvia: {order.ShipVia} \nOrderId: {order.OrderId} \nFreight: {order.Freight} \nOrderdate: {order.OrderDate}\n");
                    }

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Press ENTER to add a Customer");
                    Console.ResetColor();
                    Console.ReadLine();
                    Console.Clear();
                    AddCustomer();

                }

            

    

                void AddCustomer()
                {



                    Console.Write("Companyname: ");
                    string Companyname = Console.ReadLine();
                    Companyname = string.IsNullOrWhiteSpace(Companyname) ? null : Companyname;
                    Console.Clear();

                    Console.Write("Contactname: ");
                    string ContactName = Console.ReadLine();
                    ContactName = string.IsNullOrWhiteSpace(ContactName) ? null : ContactName;
                    Console.Clear();

                    Console.Write("ContactTitle: ");
                    string ContactTitle = Console.ReadLine();
                    ContactTitle = string.IsNullOrWhiteSpace(ContactTitle) ? null : ContactTitle;
                    Console.Clear();

                    Console.Write("Address: ");
                    string Address = Console.ReadLine();
                    Address = string.IsNullOrWhiteSpace(Address) ? null : Address;
                    Console.Clear();

                    Console.Write("City: ");
                    string City = Console.ReadLine();
                    City = string.IsNullOrWhiteSpace(City) ? null : City;
                    Console.Clear();

                    Console.Write("Region: ");
                    string Region = Console.ReadLine();
                    Region = string.IsNullOrWhiteSpace(Region) ? null : Region;
                    Console.Clear();

                    Console.Write("PostalCode: ");
                    string PostalCode = Console.ReadLine();
                    PostalCode = string.IsNullOrWhiteSpace(PostalCode) ? null : PostalCode;
                    Console.Clear();

                    Console.Write("Country: ");
                    string Country = Console.ReadLine();
                    Country = string.IsNullOrWhiteSpace(Country) ? null : Country;
                    Console.Clear();

                    Console.Write("Phone: ");
                    string Phone = Console.ReadLine();
                    Phone = string.IsNullOrWhiteSpace(Phone) ? null : Phone;
                    Console.Clear();

                    Console.Write("Fax: ");
                    string Fax = Console.ReadLine();
                    Fax = string.IsNullOrWhiteSpace(Fax) ? null : Fax;
                    Console.Clear();

                    var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                    var stringChars = new char[5];
                    var random = new Random();

                    for (int i = 0; i < stringChars.Length; i++)
                    {
                        stringChars[i] = chars[random.Next(chars.Length)];
                    }

                    var finalString = new String(stringChars);
                    

                    var newCustomer = new Models.Customer
                    {
                        CustomerId = finalString,
                        CompanyName = Companyname,
                        ContactName = ContactName,
                        ContactTitle = ContactTitle,
                        Address = Address,
                        City = City,
                        Region = Region,
                        PostalCode = PostalCode,
                        Country = Country,
                        Phone = Phone,
                        Fax = Fax
                    };

                    context.Customers.Add(newCustomer);

                    Console.WriteLine($"Companyname: {newCustomer.CompanyName} " +
                        $"\nContactname: {newCustomer.ContactName} " +
                        $"\nContacttitle: {newCustomer.ContactTitle} " +
                        $"\nAddress: {newCustomer.Address} " +
                        $"\nCity: {newCustomer.City} " +
                        $"\nRegion: {newCustomer.Region} " +
                        $"\nPostalcode: {newCustomer.PostalCode} " +
                        $"\nCountry: {newCustomer.Country}" +
                        $"\nPhone:  {newCustomer.Phone} " +
                        $"\nFax: {newCustomer.Fax} \n");

                    Console.WriteLine("Customer Added");
                        

                }



            }
        }
    }
}
