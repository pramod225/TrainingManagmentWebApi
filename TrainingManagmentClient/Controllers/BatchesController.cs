﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrainingManagmentClient.Controllers
{
    public class BatchesController : Controller
    {
        // GET: Batches
        public ActionResult Index()
        {
            return View();
        }

        // GET: Batches/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Batches/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Batches/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Batches/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Batches/Edit/5
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

        // GET: Batches/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Batches/Delete/5
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
