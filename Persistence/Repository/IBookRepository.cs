using System.Collections;
using Model;

namespace Persistence.Repository;

public interface IBookRepository: IRepository<int, Book>
{
    public IEnumerable<Book> FindAllByAuthor(string author);
    
    public IEnumerable<Book> FindAllByTitle(string title);
    public IEnumerable<Book> FindAllByTitleAndAuthor(string title, string author);
}