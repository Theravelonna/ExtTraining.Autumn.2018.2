namespace No8.Solution.Console
{
    using System;
    using No8.Solution;
    using System.Linq;
    using System.Collections.Generic;

    public class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            PrinterManager manager = new PrinterManager();
            bool t = true;
            while (t)
            {
                string name, model;

                Console.WriteLine("Select your choice:");
                Console.WriteLine("1:Add new printer");
                Console.WriteLine("2:Print on Canon");
                Console.WriteLine("3:Print on Epson");
                Console.WriteLine("4:Exit");

                var key = Console.ReadKey();

                if (key.Key == ConsoleKey.D1)
                {
                    Console.WriteLine("Enter printer name");
                    name = Console.ReadLine();
                    Console.WriteLine("Enter printer model");
                    model = Console.ReadLine();

                    if (name != "Canon" || name != "Epson")
                    {
                        Console.WriteLine("Try again!");
                        break;
                    }

                    if (name == "Canon")
                    {
                        manager.Add(new CanonPrinter(model));
                    }

                    if (name == "Epson")
                    {
                        manager.Add(new EpsonPrinter(model));
                    }
                }

                if (key.Key == ConsoleKey.D2)
                {
                    Print("Canon", manager);
                }

                if (key.Key == ConsoleKey.D3)
                {
                    Print("Epson", manager);
                }

                if (key.Key == ConsoleKey.D4)
                {
                    t = false;
                }
            }
        }

        private static void Print(string name, PrinterManager manager)
        {
            
            string model;
            var printersWithSourceName = PrinterManager.printers.Where(x => x.Name == name);

            foreach (var item in printersWithSourceName)
            {
                Console.WriteLine(manager.Display(item));
            }
            
            Console.WriteLine("Select model:");
            model = Console.ReadLine();

            List<Printer> list = new List<Printer>(printersWithSourceName);

            manager.Print(list.Find(x => x.Model == model));
        }
    }
}
