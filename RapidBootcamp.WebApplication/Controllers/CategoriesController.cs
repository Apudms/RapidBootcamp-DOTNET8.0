using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RapidBootcamp.WebApplication.DAL;
using RapidBootcamp.WebApplication.Models;

namespace RapidBootcamp.WebApplication.Controllers
{
    public class CategoriesController : Controller
    {
        private ICategory _categoryDal;

        public CategoriesController(ICategory categoryDal) 
        {
            _categoryDal = categoryDal;
        }

        #region Home / Index
        // GET: CategoriesController
        public ActionResult Index(string categoryName = "")
        {
            #region Oldest
            //List<Category> categories = new List<Category>();
            //categories.Add(new Category { CategoryId = 1, CategoryName = "Laptop Gaming" });
            //categories.Add(new Category { CategoryId = 2, CategoryName = "Laptop Office" });
            //categories.Add(new Category { CategoryId = 3, CategoryName = "Monitor" });
            //categories.Add(new Category { CategoryId = 4, CategoryName = "Smartphone" });
            //categories.Add(new Category { CategoryId = 5, CategoryName = "Mouse" });
            //categories.Add(new Category { CategoryId = 6, CategoryName = "Keyboard" });

            //return View(categories);
            #endregion

            if (TempData["Message"] != null)
            {
                ViewBag.Message = TempData["Message"];
            }
            IEnumerable<Category> categories;
            if (categoryName != "")
            {
                categories = _categoryDal.GetByCategoryName(categoryName);
            }
            else
            {
                categories = _categoryDal.GetAll();
            }

            return View(categories);
        }
        #endregion

        #region Detail Category
        // GET: CategoriesController/Details/5
        public ActionResult Details(int id)
        {
            var category = _categoryDal.GetById(id);
            return View(category);
        }
        #endregion 

        #region Create Category
        // GET: CategoriesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoriesController/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            //return Content($"Category ID: {category.CategoryId} - Category Name: {category.CategoryName}")

            try
            {
                var result = _categoryDal.Add(category);
                TempData["Message"] = $"Category {category.CategoryName} added successfully";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.ErrorMessage = "Category not added";
                return View();
            }
        }
        #endregion 

        #region Edit Category
        // GET: CategoriesController/Edit/5
        public ActionResult Edit(int id)
        {
            var category = _categoryDal.GetById(id);
            return View(category);
        }

        // POST: CategoriesController/Edit/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit(Category category)
        {
            try
            {
                var result = _categoryDal.Update(category);
                TempData["Message"] = $"Category {category.CategoryName} cannot update!";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        #endregion

        #region Delete Category
        // GET: CategoriesController/Delete/5
        public ActionResult Delete(int id)
        {
            var category = _categoryDal.GetById(id);
            return View(category);
        }

        // POST: CategoriesController/Delete/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeletePost(int CategoryId)
        {
            try
            {
                _categoryDal.Delete(CategoryId);
                TempData["Message"] = $"Category with id:{CategoryId} deleted successfully!";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.ErrorMessage = "Category not deleted";
                return View();
            }
        }
        #endregion
    }
}
