using System;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Threading;
using TechnicalTest.LemonWayService;

namespace TechnicalTest
{
    class Program
    {


        static void Main(string[] args)
        {

            //Call To Finobacci
            CallFibonacci(10);

            //Call To XmlToJson
            CallXmlToJsonMethod("< foo > bar </ foo >");
            Console.WriteLine("ServiceMethods_OwnCall");

            string userEntry = string.Empty;
            while (!string.IsNullOrEmpty(userEntry = Console.ReadLine()))
            {
                string[] parameters = userEntry.Split(' ');
                if (parameters.Length != 2)
                {
                    //Ask again when not valid
                    Console.WriteLine("Parameter Error");
                    continue;
                }
                switch (parameters[0].ToLower())
                {
                    case "fibonacci":
                        int Number = 0;
                        if (int.TryParse(parameters[1], out Number))
                            CallFibonacci(Number);
                        else
                        {
                            Console.WriteLine("Parameter Error");
                        }
                        break;   
                    case "xmltojson":
                        CallXmlToJsonMethod(parameters[1]);
                        break;
                    default:
                        //ask again if not valid
                        Console.WriteLine("Parameter Error");
                        continue;
                }

            }
        }


        private static void CallFibonacci(int value)
        {
            try
            {
                LemonWayServiceSoapClient lemonWeyService = new LemonWayServiceSoapClient("LemonWayServiceSoap");
                Console.WriteLine("Finobacci_CallMethod");
                Console.WriteLine(lemonWeyService.Fibonacci(value));
                Console.WriteLine();

                //close the service channel
                lemonWeyService.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("ServiceMethods_UnexpectedError");
            }

        }

        private static void CallXmlToJsonMethod(string xml)
        {
            try
            {

                LemonWayServiceSoapClient lemonWeyService = new LemonWayServiceSoapClient("LemonWayServiceSoap");

                Console.WriteLine("XmlToJson_CallMethod", xml);
                Console.WriteLine(lemonWeyService.XmlToJson(xml));
                Console.WriteLine();
                //close the service channel
                lemonWeyService.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("ServiceMethods_UnexpectedError");
            }
        }


       
    }
}
