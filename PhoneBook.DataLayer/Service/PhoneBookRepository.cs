using PhoneBook.DataLayer.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.DataLayer.Service
{
    public class PhoneBookRepository : IPhoneBookRepository
    {
        private PhoneEntities db = new PhoneEntities();
        public PhoneBookRepository(PhoneEntities dataSet)
        {
            db = dataSet;
        }

        public bool DeletePhoneInfo(phonebook phoneInfo)
        {
            try
            {
                db.Entry(phoneInfo).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeletePhoneInfoById(int id)
        {
            try
            {
                var phoneInfo = GetPhoneInfoById(id);
                DeletePhoneInfo(phoneInfo);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<phonebook> GetPhoneBookInfo()
        {
            return db.phonebooks.ToList();
        }

        public IEnumerable<phonebook> GetPhoneInfoByFilter(string text)
        {
            return db.phonebooks.Where(ph => ph.Name.Contains(text) ||
            ph.Mobile.Contains(text) || ph.Address.Contains(text)).ToList();
        }

        public phonebook GetPhoneInfoById(int id)
        {
            return db.phonebooks.Find(id);
        }

        public bool InserNewPhoneInfo(phonebook phoneInfo)
        {
            try
            {
                db.phonebooks.Add(phoneInfo);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdatePhoneInfo(phonebook phoneInfo)
        {
            try
            {
                db.Entry(phoneInfo).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
