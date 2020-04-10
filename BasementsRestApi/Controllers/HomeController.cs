using BasementsRestApi.Models;
using BasementsRestApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BasementsRestApi.Controllers
{
    public class HomeController : Controller
    {
        private IItemRepository _repo;

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(_repo.GetItems());
        }

        public IActionResult Edit(int itemID)
        {
            var item = _repo.GetItemByID(itemID);
            if (item != null)
            {
                return View(item);
            }
            return NotFound();
        }

        public HomeController(IItemRepository repo)
        {
            _repo = repo;
        }
    }
}
