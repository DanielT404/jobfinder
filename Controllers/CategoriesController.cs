using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JobFinder.Data;
using JobFinder.Models;
using JobFinder.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using JobFinder.Data.Repositories;

namespace JobFinder.Controllers
{
    [Authorize(Roles = "admin")]
    public class CategoriesController : Controller
    {
        private readonly DBApplicationContext _context;
        private readonly CategoriesRepository _categoriesRepository;

        public CategoriesController(DBApplicationContext context)
        {
            _context = context;
            _categoriesRepository = new CategoriesRepository(context);
        }

        [Route("/categories")]
        public ViewResult Index()
        {
            List<Category> categories = _categoriesRepository.GetCategories();
            if (TempData["ErrorMessage"] != null)
            {
                ViewBag.ErrorMessage = TempData["ErrorMessage"].ToString();
            }
            ViewBag.SelectedNav = "Dashboard";
            return View(categories);
        }

        [Route("/categories/create")]
        public ViewResult Create()
        {
            ViewBag.SelectedNav = "Dashboard";
            return View();
        }

        [Route("/categories/create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Name")] Category category)
        {
            if(ModelState.IsValid)
            {
                _categoriesRepository.AddCategory(category);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.SelectedNav = "Dashboard";
            return View(category);            
        }

        [Route("/categories/edit/{id}")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = _categoriesRepository.FindCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }
            ViewBag.SelectedNav = "Dashboard";
            return View(category);
        }

        [Route("/categories/edit/{id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("CategoryId,Name")] Category category)
        {
            if (id != category.CategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _categoriesRepository.EditCategory(category);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_categoriesRepository.CategoryExists(category.CategoryId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                ViewBag.SelectedNav = "Dashboard";
                return RedirectToAction(nameof(Index));
            }
            ViewBag.SelectedNav = "Dashboard";
            return View(category);
        }

        [Route("/categories/delete/{id}")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = _categoriesRepository.FindCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }
            ViewBag.SelectedNav = "Dashboard";
            return View(category);
        }
        
        [Route("/categories/delete/{id}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = _categoriesRepository.FindCategoryById(id);
            if(category != null)
            {
                ViewBag.SelectedNav = "Dashboard";
                if (category.JobListings.Count() < 1)
                {
                    _categoriesRepository.DeleteCategory(category);
                    return RedirectToAction(nameof(Index));
                } else
                {
                    TempData["ErrorMessage"] = $"Category '{category.Name}' has active job listings and cannot be deleted.";
                    return RedirectToAction(nameof(Index));
                }
            }
            ViewBag.SelectedNav = "Dashboard";
            return RedirectToAction(nameof(Index));
        }
    }
}
