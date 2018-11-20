using System;
using System.IO;

namespace No8.Solution
{
    /// <summary>
    /// Class Canon printer.
    /// </summary>
    public class CanonPrinter : Printer
    {
        /// <summary see cref="CanonPrinter">
        /// Constructor of class. Calles base class constructor.
        /// </summary>
        /// <param name="model">
        /// Model of printer.
        /// </param>
        public CanonPrinter(string model) : base("Canon", model)
        {
        }

        /// <summary>
        /// Override method for printing information from file.
        /// </summary>
        /// <param name="file">
        /// File from take information.
        /// </param>
        public override void Print(FileStream file)
        {
            PrinterManager.Log("Start printed on Canon");
            
            for (int i = 0; i < file.Length; i++)
            {
                // simulate printing
                Console.WriteLine(file.ReadByte());
            }

            PrinterManager.Log("End printed on Canon");
        }
    }
}
