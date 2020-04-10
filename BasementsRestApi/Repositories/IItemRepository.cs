using BasementsRestApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BasementsRestApi.Repositories
{
    public interface IItemRepository
    {
        IEnumerable<Item> GetItems();
        Item GetItemByID(int itemID);
        IEnumerable<ItemDefinition> GetItemDefinitions();
        ItemDefinition GetItemDefinitionByID(int itemDefinitionID);
        IEnumerable<User> GetUsers();
        User GetUserByID(int userID);
        void AddItem([FromBody] Item item);
        void AddUser([FromBody] User user);
        void DeleteItem(int itemID);
    }
}
