

namespace AppContacts.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using SQLite;
    using System.Linq;
    using Model;
    using System.Threading.Tasks;
    using System.Collections.ObjectModel;
    using AppContacts.Helper;

    public class ContactsDatabase
    {
        private readonly SQLiteAsyncConnection dataBase;

        public ContactsDatabase(string dbPath)
        {
            dataBase = new SQLiteAsyncConnection(dbPath);
            dataBase.CreateTableAsync<Contact>().Wait();
        }

        public async Task<List<Contact>> GetItemAsync()
        {
            var data = await dataBase.Table<Contact>().ToListAsync();
            return data;
        }
        public Task<Contact> GetItemAsync(int id)
        {
            return dataBase.Table<Contact>()
                                             .Where(c => c.Id == id).
                                             FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Contact item)
        {
            if (item.Id != 0)
            {
                return dataBase.UpdateAsync(item);
            }
            else
            {
                return dataBase.DeleteAsync(item);
            }
        }
        public Task<int> DeleteItemAsync(ContactsDatabase item)
        {
            return dataBase.DeleteAsync(item);
        }
        public async Task<ObservableCollection<IGrouping<string, Contact>>> GetAllGrouped()
        {
            IList<Contact> contacts = await App.DataBase.GetItemAsync();
            IEnumerable<Grouping<string, Contact>> sorted = new Grouping<string, Contact>[0];
            if (contacts != null)
            {
                sorted = from c in contacts
                         orderby c.Nombre
                         group c by c.Nombre[0].ToString()
                        into theGroup
                         select new Grouping<String, Contact>
                         (theGroup.Key, theGroup);
            }
            return new ObservableCollection<Grouping<string, Contact>>(sorted);
        }
    }
}
