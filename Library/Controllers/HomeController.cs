using Library.Models;
using Microsoft.AspNetCore.Mvc;
using myFriends.DAL;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Library.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        //פונקציית הצגת כל הספריות
        public IActionResult Library()
        {
            List<LibraryModel> library = Data.Get.Libraries.ToList();
            return View(library);
        }
        //פונקציית יצירת ספרייה ומדף,בקשת גט
        public IActionResult CreateLibrary()
        {
            return View(new LibraryModel());
        }
        //הכנסת הנתונים לדאטא בייס ומציגה את התוצאה,בקשת פוסט
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult AddLibrary(LibraryModel library)
        {
            Data.Get.Libraries.Add(library);
            Data.Get.SaveChanges();
            return RedirectToAction("Index");
        }
        //פונקציית הוספת ספר למדף,בקשת גט
        public IActionResult Createbook()
        {
            return View(new Books());
        }
        //הכנסת הנתונים לדאטא בייס ומציגה את התוצאה,בקשת פוסט
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult AddBook(Books book)
        {
            Data.Get.Books.Add(book);
            Data.Get.SaveChanges();
            return RedirectToAction("Index");
        }

        
        public IActionResult Privacy()
        {
            return View();
        }

        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
