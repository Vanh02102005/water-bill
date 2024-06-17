using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the customer's name: ");
            string customerName = Console.ReadLine();
            int Watermasslastmonth = GetMeterReading("Enter last month's water meter readings: ");
            int Waterblockthismonth = GetMeterReading("Enter this month's water meter readings: ");
            while ( Waterblockthismonth< Watermasslastmonth)
            {
                Console.WriteLine("Please re-enter.");
                Waterblockthismonth = GetMeterReading("Enter this month's water meter readings: ");
            }    
            int customertype = GetCustomertype();

            int numberOfPeople = 0;
            if (customertype == 1)
            {
                numberOfPeople = GetNumberOfPeople();
            }
            int consumption = Waterblockthismonth - Watermasslastmonth;                  
            double amount = CalculateWaterBill(consumption, customertype, numberOfPeople);
            Console.WriteLine("Customer name: " + customerName);
            Console.WriteLine("Enter last month's water meter readings: " + Watermasslastmonth);
            Console.WriteLine("Enter this month's water meter readings: " + Waterblockthismonth);
            Console.WriteLine("Amount of water consumed: " + consumption + " m3");
            Console.WriteLine("Total amount payable: " + amount + " VND");
        }       

        static int GetMeterReading(string prompt)
        {
            int meterReading;
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out meterReading))
                {
                    return meterReading;
                }
                Console.WriteLine("Please re-enter.");
            }
        }

        static int GetCustomertype()
        {
            int customerType;
            Console.WriteLine("Enter the customer type: ");
            Console.WriteLine(" 1.Family ");
            Console.WriteLine(" 2.Administrative agency ");
            Console.WriteLine(" 3.Production unit ");
            Console.WriteLine(" 4.Business service ");
            while (true)
            {             
                if (int.TryParse(Console.ReadLine(), out customerType) && customerType >= 1 && customerType <= 4)
                {
                    return customerType;
                }
                Console.WriteLine("Please re-enter.");
            }
        }

        static int GetNumberOfPeople()
        {
            int numberOfPeople;
            while (true)
            {
                Console.Write("Enter the number of people in the household: ");
                if (int.TryParse(Console.ReadLine(), out numberOfPeople) && numberOfPeople > 0)
                {
                    return numberOfPeople;
                }
                Console.WriteLine("Please re-enter.");
            }
        }

        

        static double CalculateWaterBill(int consumption, int customerType, int numberOfPeople)
        {
            double money = 0;
            switch (customerType)
            {
                case 1:
                    if (consumption <= 10 * numberOfPeople)
                    {
                        money = 5.973;
                    }
                    else if (consumption <= 20 * numberOfPeople)
                    {
                        money = 7.052;
                    }
                    else if (consumption <= 30 * numberOfPeople)
                    {
                        money = 8.699;
                    }
                    else
                    {
                        money = 15.929;
                    }
                    break;
                case 2:
                    money = 9.955;
                    break;
                case 3:
                    money = 11.615;
                    break;
                case 4:
                    money = 22.068;
                    break;
            }
            double waterBill = consumption * money;
            double VAT = money * 1.21;
            return waterBill + money + VAT;
        }              
    }
}
