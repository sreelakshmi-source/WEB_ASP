using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext db;
        public HomeController(ApplicationDbContext db)
        {
            this.db = db;
        }

      
        
        
        public IActionResult Index()
        {
            List<Detail> dt = new List<Detail>();
            dt = db.Detail.Where(i => i.Id != 0).ToList();
          
            return View(dt);
        }
      
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Detail dt )
        {
            var det = db.Detail.Where(i => i.Id == dt.Id).FirstOrDefault();
            if (dt != null && dt.Id == 0)
            {

                Detail detail = new Detail()
                {

                    Name = dt.Name,
                    Age = dt.Age,
                    Place = dt.Place,
                };
                await db.Detail.AddAsync(detail);
            }
            else {
                det.Name = dt.Name;
                det.Age = dt.Age;
                det.Place = dt.Place;
            }
            await  db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var update = db.Detail.Where(i => i.Id == id).FirstOrDefault();
            if (update != null)
            {
                Detail detail = new Detail()
                {
                    Id = update.Id,
                    Name = update.Name,
                    Age = update.Age,
                    Place = update.Place,
                };

                return View(detail);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {

            var delete = db.Detail.Where(i => i.Id == id).FirstOrDefault();
            if (delete != null)
            {
                Detail detail = new Detail()
                {
                    Id = delete.Id,
                    Name = delete.Name,
                    Age = delete.Age,
                    Place = delete.Place,
                };

                return View(detail);
            }
            return RedirectToAction("Index");

          
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var delete = db.Detail.Where(i => i.Id == id).FirstOrDefault();
            if (delete != null && id != 0)
            {
                db.Detail.Remove(delete);
                db.SaveChangesAsync();
            }
            return RedirectToAction("Index");


        }
    }
}