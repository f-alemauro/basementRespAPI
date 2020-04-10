using System.Collections.Generic;
using System.Net;
using BasementsRestApi.Models;
using BasementsRestApi.Repositories;
using BasementsRestApi.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BasementsRestApi.Controllers
{
    public class ItemsController : Controller
    {
        private IItemRepository _repo;

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

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <returns></returns>
        //[HttpGet("api/users")]
        //public IEnumerable<User> GetUsers()
        //{
        //    return _repo.GetUsers();
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="userID"></param>
        ///// <returns></returns>
        //[HttpGet("api/users/{userID}")]
        //public ActionResult<User> GetUserByID(int userID)
        //{
        //    return _repo.GetUserByID(userID);
        //}

        /// <summary>
        /// 
        /// </summary>
        [HttpPost("api/items")]
        public IActionResult AddItem([FromBody] Item newItem)
        {
            if (ModelState.IsValid)
            {
                _repo.AddItem(newItem);
                Response.StatusCode = (int)HttpStatusCode.OK;
                return Json(new { success = true, message = "Item added!" });
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { success = false, message = "Error in adding item" });
            }
        }

        ///// <summary>
        ///// 
        ///// </summary>
        //[HttpPost("api/users")]
        //public void AddUser([FromBody] User user)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _repo.AddUser(user);
        //    }
        //    else
        //    {

        //    }
        //}

        [HttpDelete("api/items/{itemID}")]
        public IActionResult DeleteItem(int itemID)
        {
            _repo.DeleteItem(itemID);
            return Json(new { success = true, message = "Item deleted!" });
        }

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
