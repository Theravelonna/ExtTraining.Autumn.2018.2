namespace No8.Solution
{
    /// <summary>
    /// Class with event end print.
    /// </summary>
    public class EndPrintEventArgs
    {
        /// <summary see cref="EndPrintEventArgs">
        /// Constructor of class.
        /// </summary>
        /// <param name="printer">
        /// It's printer which works.
        /// </param>
        public EndPrintEventArgs(Printer printer)
        {
            Printer = printer;
        }

        /// <summary>
        /// Public property with information about printer.
        /// </summary>
        public Printer Printer { get; private set; }

    }
}
