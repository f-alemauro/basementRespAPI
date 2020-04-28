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
        void AddItemDefinition(ItemDefinition newItemDefinition);
        ItemDefinition GetItemDefinitionByID(int itemDefinitionID);
        IEnumerable<User> GetUsers();
        User GetUserByID(int userID);
        void AddItem(Item item);
        void AddUser(User user);
        void UpdateItem(Item updatedItem);
        void DeleteItem(int itemID);
    }
}
