using JobFinder.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobFinder.Data.Repositories
{
    public class CategoriesRepository
    {
        private readonly DBApplicationContext _dbContext;

        public CategoriesRepository(DBApplicationContext context)
        {
            _dbContext = context;
        }

        public Category FindCategoryBySlug(string categorySlug)
        {
            return _dbContext.Categories.FirstOrDefault(c => c.Slug == categorySlug);
        }

        public Category FindCategoryById(int? id)
        {
            return _dbContext.Categories.Include(c => c.JobListings).First(c => c.CategoryId == id);
        }

        public List<Category> GetCategories()
        {
            return _dbContext.Categories.ToList();
        }

        public void AddCategory(Category category)
        {
            category.Slug = GenerateCategorySlug(category.Name);
            _dbContext.Add(category);
            _dbContext.SaveChanges();
        }

        public void EditCategory(Category category)
        {
            category.Slug = GenerateCategorySlug(category.Name);
            _dbContext.Update(category);
            _dbContext.SaveChanges();
        }

        public void DeleteCategory(Category category)
        {
            _dbContext.Categories.Remove(category);
            _dbContext.SaveChanges();
        }

        private string GenerateCategorySlug(string categoryName)
        {
            bool categoryNameContainSpaces = categoryName.Contains(" ");
            if (categoryNameContainSpaces)
            {
                return categoryName.Replace(" ", "-").ToLower();
            }
            else
            {
                return categoryName.ToLower();
            }
        }

        public bool CategoryExists(int id)
        {
            return _dbContext.Categories.Any(e => e.CategoryId == id);
        }
    }
}

