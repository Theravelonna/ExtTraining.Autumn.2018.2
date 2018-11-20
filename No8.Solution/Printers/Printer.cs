using System;
using System.IO;

namespace No8.Solution
{
    /// <summary>
    /// Base class for all printers.
    /// </summary>
    public abstract class Printer : IEquatable<Printer>
    {
        /// <summary see cref="Printer">
        /// Constructor of class.
        /// </summary>
        /// <param name="name">
        /// Name of printer.
        /// </param>
        /// <param name="model">
        /// Model of printer.
        /// </param>
        public Printer(string name, string model)
        {
            Name = name;
            Model = model;
        }
        
        /// <summary>
        /// Public property with information about name printer.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Public property with information about model printer.
        /// </summary>
        public string Model { get; private set; }

        /// <summary>
        /// Method cheks equality.
        /// </summary>
        /// <param name="printer">
        /// The second object for comparing.
        /// </param>
        /// <returns>
        /// Returns result of cheks equality.
        /// </returns>
        public bool Equals(Printer printer)
        {
            return this.Model == printer.Model && this.Name == printer.Name;
        }

        /// <summary>
        /// Method for printing information from file.
        /// </summary>
        /// <param name="file">
        /// File from take information.
        /// </param>
        public virtual void Print(FileStream file)
        {
            PrinterManager.Log("Start printed");
            
            for (int i = 0; i < file.Length; i++)
            {
                // simulate printing
                Console.WriteLine(file.ReadByte());
            }

            PrinterManager.Log("End printed");
        }

        /// <summary>
        /// Method for registration on events start and end print.
        /// </summary>
        /// <param name="manager">
        /// Who manages process.
        /// </param>
        public void Register(PrinterManager manager)
        {
            manager.StartPrint += StartPrintMessage;
            manager.EndPrint += EndPrintMessage;
        }

        /// <summary>
        /// Method for unregistration from events start and end print.
        /// </summary>
        /// <param name="manager">
        /// Who manages process.
        /// </param>
        public void Unregister(PrinterManager manager)
        {
            manager.StartPrint -= StartPrintMessage;
            manager.EndPrint -= EndPrintMessage;
        }

        /// <summary>
        /// Method print message about event (start print).
        /// </summary>
        /// <param name="sender">
        /// It's sender.
        /// </param>
        /// <param name="eventArgs">
        /// Object of EventArgs class.
        /// </param>
        private static void StartPrintMessage(object sender, StartPrintEventArgs eventArgs) => Console.WriteLine($"Print was started. Printer is {eventArgs.Printer.Name} - {eventArgs.Printer.Model}");

        /// <summary>
        /// Method print message about event (end print).
        /// </summary>
        /// <param name="sender">
        /// It's sender.
        /// </param>
        /// <param name="eventArgs">
        /// Object of EventArgs class.
        /// </param>
        private static void EndPrintMessage(object sender, EndPrintEventArgs eventArgs) => Console.WriteLine($"Print was ended. Printer is {eventArgs.Printer.Name} - {eventArgs.Printer.Model}");
    }
}
