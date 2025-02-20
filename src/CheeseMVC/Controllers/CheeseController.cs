﻿using Microsoft.AspNetCore.Mvc;
using CheeseMVC.Models;
using System.Collections.Generic;
using CheeseMVC.ViewModels;
using CheeseMVC.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CheeseMVC.Controllers
{
    public class CheeseController : Controller
    {
        private CheeseDbContext context;

        public CheeseController(CheeseDbContext dbContext)
        {
            context = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            IList<Cheese> cheeses = context.Cheeses.Include(c => c.Category).ToList();

            return View(cheeses);
        }

        public IActionResult Add()
        {
            AddCheeseViewModel addCheeseViewModel = new AddCheeseViewModel(context.Categories.ToList());
            return View(addCheeseViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddCheeseViewModel addCheeseViewModel)
        {
            if (ModelState.IsValid)
            {
                // Add the new cheese to my existing cheeses
                
                CheeseCategory newCheeseCategory = 
                    context.Categories.Single(c => c.ID == addCheeseViewModel.CategoryID);
                Cheese newCheese = new Cheese

                {

                    Name = addCheeseViewModel.Name,
                    Description = addCheeseViewModel.Description,
                    Category =newCheeseCategory
                  
                };
               


                context.Cheeses.Add(newCheese);
                context.SaveChanges();

                return Redirect("/Cheese");
            }

            return View(addCheeseViewModel);
        }

        public IActionResult Remove()
        {
            ViewBag.title = "Remove Cheeses";
            ViewBag.cheeses = context.Cheeses.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Remove(int[] cheeseIds)
        {
            foreach (int cheeseId in cheeseIds)
            {
                Cheese theCheese = context.Cheeses.Single(c => c.ID == cheeseId);
                context.Cheeses.Remove(theCheese);
            }

            context.SaveChanges();

            return Redirect("/");
        }
        public IActionResult Category(int id)
        {
            return Redirect("/Category");

        }
       /* CheeseCategory theCategory =
            context.Categories.Include(cat => cat.
            .Single(cat => cat.ID == id);

        //To Query for the cheese from the other side
        // of the relationship:
        /* IList<Cheese> theCheeses =context.Cheeses.Include
         (c c=> c.Category).Where(c => c.CategoryID == id)
         .ToList();
         */
        /*ViewBag.title ="Cheeses in category: " + theCategory.Name;
             return View("Index", theCategory.Cheeses);*/
    }
}
