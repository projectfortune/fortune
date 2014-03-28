using ExpenseBook.Data.Base.Impl;
using ExpenseBook.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseBook.Data
{
    public class ExpenseRepository : Repository<Expense>, IExpenseRepository
    {

    }
}
