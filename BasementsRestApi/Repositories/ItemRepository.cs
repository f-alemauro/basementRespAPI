using System;
using System.Collections.Generic;
using System.Linq;
using BasementsRestApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BasementsRestApi.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private BasementContext _context;

        public void AddItem(Item item)
        {
                _context.Items.Add(item);
                _context.SaveChanges();
        }

        public void AddUser(User user)
        {
                _context.Users.Add(user);
                _context.SaveChanges();
        }

        public void DeleteItem(int itemID)
        {
            var item = _context.Items.FirstOrDefault(i => i.ItemID == itemID);
            if (item != null)
            {
                _context.Items.Remove(item);
                _context.SaveChanges();
            }

        }

        public void UpdateItem(Item updatedItem)
        {
            var itemToUpdate = GetItemByID(updatedItem.ItemID);
            if (itemToUpdate != null)
            {
                itemToUpdate.AddedOn = updatedItem.AddedOn;
                itemToUpdate.ExpireOn = updatedItem.ExpireOn;
                itemToUpdate.Quantity = updatedItem.Quantity;
                _context.Items.Update(itemToUpdate);
                _context.SaveChanges();
            }            
        }

        public Item GetItemByID(int itemID)
        {
            return _context.Items
                .Include(i => i.User)
                .Include(i => i.ItemDefinition)
                .Where(i => i.ItemID == itemID).FirstOrDefault();
        }

        public ItemDefinition GetItemDefinitionByID(int itemDefinitionID)
        {
            return _context.ItemDefinitions.Where(id => id.ItemDefinitionID == itemDefinitionID).FirstOrDefault();
        }

        public void AddItemDefinition(ItemDefinition newItemDefinition)
        {
            _context.ItemDefinitions.Add(newItemDefinition);
            _context.SaveChanges();
        }

        public IEnumerable<ItemDefinition> GetItemDefinitions()
        {
            return _context.ItemDefinitions
                .ToList();
        }

        public IEnumerable<Item> GetItems()
        {
            return _context.Items
                .Include(i => i.User)
                .Include(i => i.ItemDefinition)
                .ToList();
        }

        public User GetUserByID(int userID)
        {
            return _context.Users.Where(u => u.UserID == userID).Include(u => u.Items).FirstOrDefault();
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Users
                .Include(u => u.Items)
                .ToList();
        }

        public ItemRepository(BasementContext context)
        {
            _context = context;
        }

    }
}
