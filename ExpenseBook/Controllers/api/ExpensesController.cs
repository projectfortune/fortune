using ExpenseBook.Data;
using ExpenseBook.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ExpenseBook.Controllers.api
{
    public class ExpensesController : ApiController
    {
        IExpenseRepository rep = new ExpenseRepository();

        public IEnumerable<Expense> GetExpenses()
        {
            return rep.GetAll();
        }


        public Expense GetExpense(int id)
        {
            Expense expense = rep.Find(exp => exp.Id == id).FirstOrDefault();
            if (expense == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return expense;
        }

        // PUT api/Default1/5
        public HttpResponseMessage PutExpense(int id, Expense expense)
        {
            if (ModelState.IsValid && id == expense.Id)
            {
                //rep. db.Entry(expense).State = EntityState.Modified;

                try
                {
                    rep.SaveChanges();
                }
                catch (Exception)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // POST api/Default1
        public HttpResponseMessage PostExpense(Expense expense)
        {
            if (ModelState.IsValid)
            {
                rep.Add(expense);
                rep.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, expense);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = expense.Id }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/Default1/5
        public HttpResponseMessage DeleteExpense(int id)
        {
            Expense expense = rep.Find(exp => exp.Id == id).FirstOrDefault();
            if (expense == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            rep.Delete(expense);

            try
            {
                rep.SaveChanges();
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK,expense);
        }

        
    }
}
