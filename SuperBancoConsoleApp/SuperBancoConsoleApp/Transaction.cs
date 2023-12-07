using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperBancoConsoleApp
{
    internal class Transaction
    {
        public long Number {  get; }
        public double Value {  get; }
        public DateTime Date {  get; }
        public string Description {  get; }
        public Transaction(long number, double value, DateTime date, string description)
        {
            this.Number = number;
            this.Value = value;
            this.Date = date;
            this.Description = description;
        }
        public override string ToString()
        {
            return "";
        }

    }
}
