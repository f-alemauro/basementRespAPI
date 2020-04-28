using BasementsRestApi.Models;
using BasementsRestApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        [HttpPost("api/itemDefinitions")]
        public IActionResult AddItemDefinition([FromBody]ItemDefinition newItemDef)
        {
            if (ModelState.IsValid)
            {
                _repo.AddItemDefinition(newItemDef);
                Response.StatusCode = (int)HttpStatusCode.OK;

                return Json(new
                {
                    success = true,
                    CssClassName = "alert-success",
                    Title = "Success!",
                    Message = "Item definition added correctly.",
                    data = newItemDef
                });
            }
            else
            {
                return Json(new
                {
                    success = false,
                    CssClassName = "alert-warning",
                    Title = "Error!",
                    Message = "Item definition not added."
                    //data = newItem
                });
            }
        }
           
        

        public ItemDefinitionController(IItemRepository repo)
        {
            _repo = repo;
        }
    }
}
