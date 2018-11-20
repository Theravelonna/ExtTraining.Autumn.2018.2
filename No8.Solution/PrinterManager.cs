using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace No8.Solution
{
    /// <summary>
    /// Class Printer manager.
    /// </summary>
    public class PrinterManager
    {
        /// <summary>
        /// List with information about printers.
        /// </summary>
        public static List<Printer> Printers { get; private set; }

        /// <summary see cref="CanonPrinter">
        /// Static constructor of class. Initialises list.
        /// </summary>
        /// <param name="model">
        /// Model of printer.
        /// </param>
        static PrinterManager()
        {
            Printers = new List<Printer>();
        }

        /// <summary>
        /// List events for start print.
        /// </summary>
        public event EventHandler<StartPrintEventArgs> StartPrint = delegate { };

        /// <summary>
        /// List events for end print.
        /// </summary>
        public event EventHandler<EndPrintEventArgs> EndPrint = delegate { };

        /// <summary>
        /// Adds new printer.
        /// </summary>
        /// <param name="newPrinter">
        /// New printer.
        /// </param>
        public void Add(Printer newPrinter)
        {
            if (!Printers.Contains(newPrinter))
            {
                Printers.Add(newPrinter);
                Log($"Printer {newPrinter.Name} {newPrinter.Model} added");
            }
        }

        /// <summary>
        /// Method for printing information from file.
        /// </summary>
        /// <param name="printer">
        /// Printer which will print.
        /// </param>
        public void Print(Printer printer)
        {
            if (Printers.Contains(printer))
            {
                Log("Print started");
                printer.Register(this);
                OnStartPrint(new StartPrintEventArgs(printer));
                StartPrinting(printer);
                OnEndPrint(new EndPrintEventArgs(printer));
                printer.Unregister(this);
                Log("Print finished");
            }
            else
            {
                Log("Printer unavailable for printing.");
            }
        }

        /// <summary>
        /// Method print information about printer.
        /// </summary>
        /// <param name="printer">
        /// The printer.
        /// </param>
        /// <returns>
        /// String with information.
        /// </returns>
        public string Display(Printer printer)
        {
            return string.Format($"{printer.Name} - {printer.Model}");
        }
        
        /// <summary>
        /// Method logges information about actions.
        /// </summary>
        /// <param name="_string">
        /// String with information about actions.
        /// </param>
        internal static void Log(string _string)
        {
            FileStream sourceStream = File.Open("log.txt", FileMode.OpenOrCreate);
            Encoding unicode = Encoding.Unicode;
            byte[] bytes = unicode.GetBytes(_string);
            sourceStream.Write(bytes, 0 , bytes.Length);
            sourceStream.Close();
        }

        /// <summary>
        /// Method starts event StartPrint.
        /// </summary>
        /// <param name="obj">
        /// Object of StartPrintEventArgs.
        /// </param>
        protected virtual void OnStartPrint(StartPrintEventArgs obj)
        {
            StartPrint?.Invoke(this, obj);
        }

        /// <summary>
        /// Method starts event EndPrint.
        /// </summary>
        /// <param name="obj">
        /// Object of EndPrintEventArgs.
        /// </param>
        protected virtual void OnEndPrint(EndPrintEventArgs obj)
        {
            EndPrint?.Invoke(this, obj);
        }

        /// <summary>
        /// Method does action for printing information about printer.
        /// </summary>
        /// <param name="printer">
        /// The printer.
        /// </param>
        private static void StartPrinting(Printer printer)
        {
            try
            {
                var o = new OpenFileDialog();
                o.ShowDialog();
                var file = File.OpenRead(o.FileName);
                printer.Print(file);
            }
            catch (FileNotFoundException)
            {
                Log("Print was faild. File wasn't found.");
            }
            catch (FileLoadException)
            {
                Log("Print was faild. File wasn't load.");
            }
            catch (Exception)
            {
                Log("Print was faild.");
            }
        }
    }
}
