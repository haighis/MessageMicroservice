using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Akka.Actor;
using Akka.Routing;
using DataModel;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class MessageController : Controller
    {
        // GET: Todo
        public ActionResult Index()
        {
            return View("Create");
        }

        // GET: Todo/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Todo/Create
        public ActionResult Create()
        {
            ViewBag.Title = "Create Todo";
            return View();
        }

        // POST: Todo/Create
        [HttpPost]
        public ActionResult Create(MessageViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var taskName = model.Message;

                    var actor = SystemActors.TodoCoordinator;

                    actor.Tell(new Message(taskName,Guid.NewGuid()));
                    var routees = actor.Ask<Routees>(new GetRoutees());
                    var hasRoutees = routees.Result.Members.Any();
                    //Console.WriteLine("has routees" + routees.Result.Members.Any());
                }

                return RedirectToAction("Index", "Home");
            }
            catch (System.Exception ex)
            {
                return View();
            }
        }

        // GET: Todo/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Todo/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Todo/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Todo/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}