using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Detail(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var categoryDb = _db.Categories.Find(id);
            // var categoryFirst = _db.Categories.FirstOrDefault(u=>u.Id==id);
            // var categorysingle=_db.Categories.SingleOrDefault(u=>u.Id==id);
            if (categoryDb == null)
            {
                return NotFound();
            }
            return View(categoryDb);
        }
        public IActionResult Index()
        {
            IEnumerable<Category> CategoryList = _db.Categories;
            return View(CategoryList);
        }

        //get

        public IActionResult Create()
        {
            return View();
        }

        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            //server side validation
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "Display order cannot exactly match the name");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Category has Created Successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //get
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var categoryDb = _db.Categories.Find(id);
            // var categoryFirst = _db.Categories.FirstOrDefault(u=>u.Id==id);
            // var categorysingle=_db.Categories.SingleOrDefault(u=>u.Id==id);
            if (categoryDb == null)
            {
                return NotFound();
            }
            return View(categoryDb);
        }

        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            //server side validation
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "Display order cannot exactly match the name");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category has updated Successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var categoryDb = _db.Categories.Find(id);
            // var categoryFirst = _db.Categories.FirstOrDefault(u=>u.Id==id);
            // var categorysingle=_db.Categories.SingleOrDefault(u=>u.Id==id);
            if (categoryDb == null)
            {
                return NotFound();
            }
            return View(categoryDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
          var del=  _db.Categories.Find(id);
            if (del==null)
            {
                return NotFound();
            }
            _db.Categories.Remove(del);
            _db.SaveChanges();
            TempData["success"] = "Category has Deleted Successfully";
            return RedirectToAction("Index");


        }
    }
}
