using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasementsRestApi.Models;
using BasementsRestApi.Repositories;
using Microsoft.AspNetCore.Mvc;


namespace BasementsRestApi.Controllers
{
    public class UsersController : Controller
    {
        private IItemRepository _repo;

        [HttpGet("api/users")]
        public IActionResult GetUsersJson()
        {
            var data = _repo.GetUsers();
            return Json(new
            {
                success = true,
                data
            });
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        public UsersController(IItemRepository repo)
        {
            _repo = repo;
        }
}
}
