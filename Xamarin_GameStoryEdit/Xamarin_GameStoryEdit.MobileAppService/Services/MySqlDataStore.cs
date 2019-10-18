using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin_GameStoryEdit.Models;

namespace Xamarin_GameStoryEdit.MobileAppService.Services
{
    public class MySqlDataStore : IDataStore<Item>
    {
        IEnumerable<Item> items;
        private CoreDbContext _CoreDbContext = new CoreDbContext();

        public MySqlDataStore()
        {
            items = new List<Item>();
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            if (forceRefresh)
            {
                items = await Task.Run(() => _CoreDbContext.Set<Item>().ToList());
            }

            return items;
        }

        public async Task<Item> GetItemAsync(string id)
        {
            if (id != null)
            {
                return await _CoreDbContext.Set<Item>().FindAsync(id);
            }

            return null;
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            if (item == null)
                return false;

            try
            {
                await _CoreDbContext.Set<Item>().AddAsync(item);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            if (item == null || item.Id == null)
                return false;

            try
            {
                await Task.Run(() => _CoreDbContext.Set<Item>().Update(item));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
                return false;

            try
            {
                await Task.Run(() => _CoreDbContext.Set<Item>().Remove(items.First(_item => _item.Id.Equals(id))));
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
