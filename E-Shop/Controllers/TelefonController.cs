using E_Shop.Entitites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace E_Shop.Controllers
{
    public class TelefonController : Controller
    {


        private readonly EstoreContext _context;

        public TelefonController(EstoreContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            var Phones = _context.Iphones.ToList();

            return View(Phones);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {

            var be = _context.Iphones.FirstOrDefault(b => b.Id == id);

            return View(be);

        }

        public IActionResult Add()
        {

            ViewBag.Kategoriler = new SelectList(_context.Kategorilers, "KategoriId", "KategoriAdi");

            return View();
        }

        [HttpPost]
        public IActionResult AddPost(Iphone ıphone)
        {
            if (ModelState.IsValid)
            {
                _context.Iphones.Add(ıphone);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Kategoriler = new SelectList(_context.Kategorilers, "KategoriId", "KategoriAdi");
            return View(ıphone);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Kategoriler = new SelectList(_context.Kategorilers, "KategoriId", "KategoriAdi");
            var be = _context.Iphones.FirstOrDefault(b => b.Id == id);
            return View(be);
        }

        [HttpPost]
        public IActionResult Edit(Iphone phone)

        {
            if (ModelState.IsValid)
            {
                _context.Iphones.Update(phone);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(phone);

        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var Tel = _context.Iphones.FirstOrDefault(X => X.Id == id);

            return View(Tel);
                                            
        }

        [HttpPost]
        public IActionResult DeletePost(int id)
        {
            var Tel = _context.Iphones.FirstOrDefault(X => X.Id == id);

            if (Tel == null)
            {
                return NotFound();
            }


            _context.Iphones.Remove(Tel);
            _context.SaveChanges();

            return RedirectToAction("Index");

        }
    }
}

