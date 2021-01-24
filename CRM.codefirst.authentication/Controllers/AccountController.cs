using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CRM.codefirst.authentication.Models;
using PagedList;
using PagedList.Mvc;

namespace CRM.codefirst.authentication.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private CRMDbContext db = new CRMDbContext();

        // GET: Account
        public ActionResult Index(string order, int? page)
        { 
            var accounts = from acc in db.Accounts select acc;
            accounts = Sort(accounts,order);
            int PageNumber=page?? 1;
            return View(accounts.ToPagedList(PageNumber,1));
}
        private IQueryable<Account> Sort(IQueryable<Account> accounts, string order)
        {
            switch (order)
            {
                case "name":
                    accounts = accounts.OrderBy(a => a.Name);
                    break;
                case "Interest":
                    accounts = accounts.OrderBy(a => a.Interest);
                    break;
                case "Added":
                    accounts = accounts.OrderBy(a => a.AddedDate);
                    break;
                default:
                    accounts = accounts.OrderBy(a => a.Id);
                    break;

            }
            return accounts;
        }

        // GET: Account/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // GET: Account/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Account/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AccountViewModel account)
        {
            if (ModelState.IsValid)
            {
                db.Accounts.Add(new Account {
                    Name=account.Name,
                    Interest=account.Interest,
                    MinimumBalance=account.MinimumBalance,
                    AddedDate=DateTime.Now,
                    Status=account.Status
                });
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(account);
        }

        // GET: Account/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // POST: Account/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Interest,MinimumBalance,AddedDate,ModifiedDate,Status")] Account account)
        {
            if (ModelState.IsValid)
            {
                db.Entry(account).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(account);
        }

        // GET: Account/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // POST: Account/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Account account = db.Accounts.Find(id);
            db.Accounts.Remove(account);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
