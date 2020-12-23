using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.DataLayer.Repository
{
    public interface IPhoneBookRepository
    {
        List<phonebook> GetPhoneBookInfo();
        phonebook GetPhoneInfoById(int id);
        bool InserNewPhoneInfo(phonebook phoneInfo);
        bool DeletePhoneInfo(phonebook phoneInfo);
        bool DeletePhoneInfoById(int id);
        bool UpdatePhoneInfo(phonebook phoneInfo);
        IEnumerable<phonebook> GetPhoneInfoByFilter(string text);
    }
}
