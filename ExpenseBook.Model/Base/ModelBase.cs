using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseBook.Model.Base
{
    public abstract class ModelBase
    {
        protected ModelBase()
        {
            AddedDate = DateTime.Now;
            LastUpdate = DateTime.Now;
        }
        
        public DateTime AddedDate { get; set; }

       
        public DateTime LastUpdate { get; set; }
       
        public int LastUpdatedBy { get; set; }
    }
}
