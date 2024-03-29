﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Piton.Domain.Abstract;

namespace Piton.WebUI.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private IProductRepository repository;

        public AdminController(IProductRepository repo)
        {
            repository = repo;
        }
        //
        // GET: /Admin/

        public ActionResult Index()
        {
            return View(repository.Products);
        }

    }
}
