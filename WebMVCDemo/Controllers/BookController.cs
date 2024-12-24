using Application.DTOs;
using Application.IUnitOfWork;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Mapper;

namespace WebMVCDemo.Controllers
{
    [Authorize(Roles = "Admin")]
    public class BookController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly BookMapper _bookMapper;

        public BookController(IUnitOfWork unitOfWork, BookMapper bookMapper)
        {
            _unitOfWork = unitOfWork;
            _bookMapper = bookMapper;
        }

        private async Task PopulateCategories()
        {
            var categories = await _unitOfWork.Categories.GetAllAsync(); 
            if (categories == null || !categories.Any())
            {
                categories = new List<Category>(); 
            }
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
        }


        public async Task<IActionResult> Index()
        {
            var books = await _unitOfWork.Books.GetAll();
            var bookDTOs = _bookMapper.ToListDTO(books);
            return View(bookDTOs);
        }

        public async Task<IActionResult> Detail(int id)
        {
            var book = await _unitOfWork.Books.Get(id);
            if (book == null)
            {
                return NotFound();
            }
            var bookDTO = _bookMapper.ToDTO(book);
            return View(bookDTO);
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            await PopulateCategories();
            if (ViewBag.Categories == null)
            {
                throw new Exception("Categories could not be loaded.");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BookDTO book)
        {
            if (ModelState.IsValid)
            {
                var bookEntity = _bookMapper.ToEntity(book);
                await _unitOfWork.Books.AddAsync(bookEntity);
                await _unitOfWork.CommitAsync();
                return RedirectToAction("Index");
            }
            await PopulateCategories();
            return View(book);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            await PopulateCategories();
            var book = await _unitOfWork.Books.Get(id);
            if (book == null)
            {
                return NotFound();
            }

            var bookDTO = _bookMapper.ToDTO(book);

            return View(bookDTO);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BookDTO book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var bookEntity = _bookMapper.ToEntity(book);
                await _unitOfWork.Books.UpdateAsync(bookEntity);
                await _unitOfWork.CommitAsync();
                return RedirectToAction("Index");
            }
            return View(book);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var book = await _unitOfWork.Books.Get(id);
            if (book == null)
            {
                return NotFound();
            }

            await _unitOfWork.Books.DeleteAsync(id);
            await _unitOfWork.CommitAsync();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> SearchName(string name)
        {
            if (string.IsNullOrEmpty(name)) name = "";
            var books = await _unitOfWork.Books.SearchName(name);
            var bookDTOs = _bookMapper.ToListDTO(books);
            return View("Index", bookDTOs);
        }
    }
}
