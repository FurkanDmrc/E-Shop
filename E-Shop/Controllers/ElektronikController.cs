using E_Shop.Entitites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace E_Shop.Controllers
{
    public class ElektronikController : Controller
    {

        private readonly EstoreContext _context;

        public ElektronikController(EstoreContext context)
        {
            _context = context;
        }



        public IActionResult Index()
        {

            var Elektronikler = _context.Elektroniks.ToList();
            return View(Elektronikler);
        }


        [HttpGet]
        public IActionResult Details(int id)
        {

            var be = _context.Elektroniks.FirstOrDefault(b => b.Id == id);

            return View(be);

        }

        public IActionResult Add()
        {

            ViewBag.Kategoriler = new SelectList(_context.Kategorilers, "KategoriId", "KategoriAdi");

            return View();
        }

        [HttpPost]
        public IActionResult AddPost(Elektronik elekt)
        {
            if (ModelState.IsValid)
            {
                _context.Elektroniks.Add(elekt);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Kategoriler = new SelectList(_context.Kategorilers, "KategoriId", "KategoriAdi");
            return View(elekt);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var Elektr = _context.Elektroniks.FirstOrDefault(x => x.Id == id);

            return View(Elektr);
        }

        [HttpPost]
        public IActionResult Edit(Elektronik elektronik)
        {
            if (ModelState.IsValid)
            {
                _context.Elektroniks.Update(elektronik);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(elektronik);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var Elekt = _context.Elektroniks.FirstOrDefault(X => X.Id == id);

            return View(Elekt);

        }

        [HttpPost]
        public IActionResult DeletePost(int id)
        {
            var Elekt = _context.Elektroniks.FirstOrDefault(X => X.Id == id);

            if (Elekt == null)
            {
                return NotFound();
            }


            _context.Elektroniks.Remove(Elekt);
            _context.SaveChanges();

            return RedirectToAction("Index");

        }
    }
}
