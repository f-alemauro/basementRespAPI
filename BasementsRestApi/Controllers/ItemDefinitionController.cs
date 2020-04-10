using BasementsRestApi.Models;
using BasementsRestApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasementsRestApi.Controllers
{
    public class ItemDefinitionController:Controller
    {
        private IItemRepository _repo;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("api/itemDefinitions")]
        public IActionResult GetItemDefinitions()
        {
            var data = _repo.GetItemDefinitions();
            return Json(new
            {
                success = true,
                data
            });
        }


        public ItemDefinitionController(IItemRepository repo)
        {
            _repo = repo;
        }
    }
}
