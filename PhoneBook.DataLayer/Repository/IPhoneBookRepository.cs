using System.Collections.Generic;


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
