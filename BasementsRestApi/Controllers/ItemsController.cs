using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using BasementsRestApi.Models;
using BasementsRestApi.Repositories;
using BasementsRestApi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BasementsRestApi.Controllers
{
    public class ItemsController : Controller
    {
        private IItemRepository _repo;

        #region action for views
        public IActionResult Index()
        {
            return View(GetItems());
        }

        public IActionResult Edit(int itemID)
        {
            var item = GetItemByID(itemID);
            if (item != null)
            {
                return View(item);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Edit(Item updatedItem)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                try
                {
                    var result = UpdateItem(updatedItem);
                    TempData["UserMessage"] = JsonConvert.SerializeObject(
                    new UserMessageVM
                    {
                        CssClassName = "alert-success",
                        Title = "Success!",
                        Message = "Item updated correctly."
                    });

                    
                }
                catch
                {
                    TempData["UserMessage"] = JsonConvert.SerializeObject(
                    new UserMessageVM
                    {
                        CssClassName = "alert-error",
                        Title = "Error!",
                        Message = "Error in updating item"
                    });
                }
                return RedirectToAction("Index");
            }
            return View(updatedItem);
        }
        #endregion

        #region api calls
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("api/items")]
        public IEnumerable<Item> GetItems()
        {
            return  _repo.GetItems();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemID"></param>
        /// <returns></returns>
        [HttpGet("api/items/{itemID}")]
        public Item GetItemByID(int itemID)
        {
            return _repo.GetItemByID(itemID);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("api/items/definitions/{itemDefinitionID}")]
        public ItemDefinition GetItemDefinitionByID(int itemDefinitionID)
        {
            return _repo.GetItemDefinitionByID(itemDefinitionID);
        }

        [HttpPut("api/items")]
        public IActionResult UpdateItem(Item updatedItem)
        {
            if (ModelState.IsValid)
            {
                _repo.UpdateItem(updatedItem);
                Response.StatusCode = (int)HttpStatusCode.OK;
                return Json(new { success = true, message = "Item updated!" });
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { success = false, message = "Error in updating item" });
            }
        }
           

        /// <summary>
        /// 
        /// </summary>
        [HttpPost("api/items")]
        public IActionResult AddItem([FromBody] Item newItem)
        {
            if (ModelState.IsValid)
            {

                _repo.AddItem(newItem);
                var itemDef = _repo.GetItemDefinitionByID(newItem.ItemDefinitionID);
                var user = _repo.GetUserByID(newItem.UserID);

                newItem.ItemDefinition = itemDef;
                newItem.User = user;
                
                //TempData["UserMessage"] = JsonConvert.SerializeObject(
                //  new UserMessageVM
                //  {
                //      CssClassName = "alert-success",
                //      Title = "Success!",
                //      Message = "Item added correctly."
                //  });

                Response.StatusCode = (int)HttpStatusCode.OK;

                return Json(new {
                    success= true,
                    CssClassName = "alert-success",
                    Title = "Success!",
                    Message = "Item added correctly.",
                    data = newItem });
            }
            else
            {
                //TempData["UserMessage"] = JsonConvert.SerializeObject(
                //  new UserMessageVM
                //  {
                //      CssClassName = "alert-warning",
                //      Title = "Error!",
                //      Message = "Error in adding item"
                //  });
                //Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new
                {
                    success= false,
                    CssClassName = "alert-warning",
                    Title = "Error!",
                    Message = "Item not added."
                    //data = newItem
                });
            }
        }

        [HttpPost("api/items/{itemID}/{quantity}")]
        public IActionResult UpdateItemQuantity(int itemID, int quantity)
        {
            var item = _repo.GetItemByID(itemID);
            if (item!= null)
            {
                item.Quantity = quantity;
                _repo.UpdateItem(item);
                Response.StatusCode = (int)HttpStatusCode.OK;
                return Json(new { success = true, message = "Item quantity updated!" });
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.NotFound;
                return Json(new { success = false, message = "Error in updating item quantity" });
            }
        }

        [HttpDelete("api/items/{itemID}")]
        public IActionResult DeleteItem(int itemID)
        {
            _repo.DeleteItem(itemID);
            return Json(new { success = true, message = "Item deleted!" });
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="repo"></param>
        public ItemsController(IItemRepository repo)
        {
            _repo = repo;
        }
    }
}
