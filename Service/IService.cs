using System.Collections;
using Model;
using Persistence.Repository;

namespace Service;

public interface IService
{
    public int GetNumberOfAvailableBooks(int bookId);
    public bool IsAvailable(int bookId);
    public BookLoan LoanBook(BookLoan bookLoan);
    public BookLoan ReturnBook(BookLoan bookLoan);
    public IEnumerable<Book> GetAllBooks();
    public IEnumerable<BookLoan> GetAllLoans();
    public Book FindBookById(int id);
    public BookLoan FindLoanById(int id);
    public IEnumerable<Book> FindBooksByAuthor(string author);
    public IEnumerable<Book> FindBooksByTitle(string title);
    public IEnumerable<Book> FindBooksByTitleAndAuthor(string title, string author);
}