using System;

namespace No8.Solution
{
    /// <summary>
    /// Class with event start print.
    /// </summary>
    public class StartPrintEventArgs : EventArgs
    {
        /// <summary see cref="StartPrintEventArgs">
        /// Constructor of class.
        /// </summary>
        /// <param name="printer">
        /// It's printer which works.
        /// </param>
        public StartPrintEventArgs(Printer printer)
        {
            Printer = printer;
        }
        
        /// <summary>
         /// Public property with information about printer.
         /// </summary>
        public Printer Printer { get; private set; }
    }
}
