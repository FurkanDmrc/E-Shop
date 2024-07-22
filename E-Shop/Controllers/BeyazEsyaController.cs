using E_Shop.Entitites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace E_Shop.Controllers
{
    public class BeyazEsyaController : Controller
    {


        private readonly EstoreContext _context;

        public BeyazEsyaController(EstoreContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            var beyazEsya = _context.BeyazEsyas.ToList();

            return View(beyazEsya);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {

            var be = _context.BeyazEsyas.FirstOrDefault(b => b.Id == id);

            return View(be);

        }

        public IActionResult Add()
        {

            ViewBag.Kategoriler = new SelectList(_context.Kategorilers, "KategoriId", "KategoriAdi");

            return View();
        }

        [HttpPost]
        public IActionResult AddPost(BeyazEsya beyazE)
        {
            if (ModelState.IsValid)
            {
                _context.BeyazEsyas.Add(beyazE);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Kategoriler = new SelectList(_context.Kategorilers, "KategoriId", "KategoriAdi");
            return View(beyazE);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var be = _context.BeyazEsyas.FirstOrDefault(x => x.Id == id);
            return View(be);

        }


        [HttpPost]
        public IActionResult Edit(BeyazEsya beyazEsya)
        {

            if (ModelState.IsValid)
            {
                _context.BeyazEsyas.Update(beyazEsya);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(beyazEsya);
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var beyazE = _context.BeyazEsyas.FirstOrDefault(X => X.Id == id);

            return View(beyazE);

        }

        [HttpPost]
        public IActionResult DeletePost(int id)
        {
            var beyazE = _context.BeyazEsyas.FirstOrDefault(X => X.Id == id);

            if (beyazE == null)
            {
                return NotFound();
            }


            _context.BeyazEsyas.Remove(beyazE);
            _context.SaveChanges();

            return RedirectToAction("Index");

        }
    }
}
