using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThucHanhBuoi2.Models;

namespace ThucHanhBuoi2.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public string HelloTeacher(string university)
        {
            return "Nguyen Dinh Anh - Unviersity: " + university;
        }
        public ActionResult ListBook()
        {
            var books = new List<string>();
            books.Add("HTML & CSS5 The complete Manual - Author Name Book 1");
            books.Add("HTML & CSS Responsive Web Design cookbook - Author Name Book 2");
            books.Add("Professional APS.NET MVC5 - Author Name Book 2");
            ViewBag.Books = books;
            return View();
        }
        public ActionResult ListBookModel()
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML & CSS5 The complete Manual", "Author Name Book 1","/Content/Image/book1cover.png"));
            books.Add(new Book(2, "HTML & CSS Responsive Web Design cookbook","Author Name Book 2", "/Content/Image/book2cover.png"));
            books.Add(new Book(3, "Professional APS.NET MVC5"," Author Name Book 2", "/Content/Image/book3cover.png"));
            return View(books);
        }
        public ActionResult EditBook(int id)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML & CSS5 The complete Manual", "Author Name Book 1", "/Content/Image/book1cover.png"));
            books.Add(new Book(2, "HTML & CSS Responsive Web Design cookbook", "Author Name Book 2", "/Content/Image/book2cover.png"));
            books.Add(new Book(3, "Professional APS.NET MVC5", " Author Name Book 2", "/Content/Image/book3cover.png"));
            Book book = new Book();
            foreach(Book b in books)
            {
                if(b.Id==id)
                {
                    book = b;
                    break;
                }
            }
            if(book==null)
            {
                return HttpNotFound();
            }
            return View(book);
        }
        [HttpPost,ActionName("EditBook")]
        [ValidateAntiForgeryToken]
        public ActionResult EditBook(int id,string title,string author, string image_cover)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML & CSS5 The complete Manual", "Author Name Book 1", "/Content/Image/book1cover.png"));
            books.Add(new Book(2, "HTML & CSS Responsive Web Design cookbook", "Author Name Book 2", "/Content/Image/book2cover.png"));
            books.Add(new Book(3, "Professional APS.NET MVC5", " Author Name Book 2", "/Content/Image/book3cover.png"));
            Book book = new Book();
            if(id==null)
            {
                HttpNotFound();
            }
            foreach(Book b in books)
            {
                if(b.Id==id)
                {
                    b.Title = title;
                    b.Author = author;
                    b.Image_cover = image_cover;
                    break;
                }
            }
            return View("ListBookModel",books);
        }
        public ActionResult CreateBook()
        {
            return View();
        }
        [HttpPost,ActionName("CreateBook")]
        [ValidateAntiForgeryToken]
        public ActionResult Contact([Bind(Include ="Id,Title,Author,Image_cover")]Book book)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML & CSS5 The complete Manual", "Author Name Book 1", "/Content/Image/book1cover.png"));
            books.Add(new Book(2, "HTML & CSS Responsive Web Design cookbook", "Author Name Book 2", "/Content/Image/book2cover.png"));
            books.Add(new Book(3, "Professional APS.NET MVC5", " Author Name Book 2", "/Content/Image/book3cover.png"));
            try
            {
                if(ModelState.IsValid)
                {
                    books.Add(book);
                }
            }
            catch(RetryLimitExceedException)
            {
                ModelState.AddModelError("", "Error Save Data");
            }
            return View("ListBookModel", books);
        }
    }
}