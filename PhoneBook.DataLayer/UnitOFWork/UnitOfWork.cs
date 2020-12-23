using PhoneBook.DataLayer.Repository;
using PhoneBook.DataLayer.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.DataLayer.UnitOFWork
{
    public class UnitOfWork : IDisposable
    {
        PhoneEntities db = new PhoneEntities();

        private IPhoneBookRepository _phoneBookRepository;
        public IPhoneBookRepository PhoneBookRepository 
        {
            get
            {
                if (_phoneBookRepository == null)
                {
                    _phoneBookRepository = new PhoneBookRepository(db);
                }
                return _phoneBookRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
