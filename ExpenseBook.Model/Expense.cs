using ExpenseBook.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseBook.Model
{
    public class Expense : ModelBase
    {
        public int Id { get; set; }

        public int Description { get; set; }

        public int Note { get; set; }

        public decimal Amount { get; set; }

        public DateTime Time { get; set; }

        public ExpenseType ExpenseType { get; set; }

        public PaymentMode PaymentMode { get; set; }
    }
}
