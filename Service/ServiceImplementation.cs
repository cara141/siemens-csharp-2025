using Model;
using Persistence.Repository;

namespace Service;

public class ServiceImplementation: IService
{
    private readonly IBookRepository _bookRepository;
    private readonly IBookLoanRepository _bookLoanRepository;
    
    public ServiceImplementation(IBookRepository bookRepository, IBookLoanRepository bookLoanRepository)
    {
        _bookRepository = bookRepository;
        _bookLoanRepository = bookLoanRepository;
    }
    
    public int GetNumberOfAvailableBooks(int bookId)
    {
        var book = _bookRepository.FindOne(bookId);
        if (book == null)
        {
            throw new ArgumentException("Book not found");
        }

        var numberOfLoans = _bookLoanRepository.FindAll().Count(bl => bl.BookId == bookId);
        return book.Quantity - numberOfLoans;
    }

    public bool IsAvailable(int bookId)
    {
        if(GetNumberOfAvailableBooks(bookId) > 0)
        {
            return true;
        }
        return false;
    }
    
    public BookLoan LoanBook(BookLoan bookLoan)
    {
        var book = _bookRepository.FindOne(bookLoan.BookId);
        if (book == null)
        {
            throw new ArgumentException("Book not found");
        }

        if (!IsAvailable(bookLoan.BookId))
        {
            throw new InvalidOperationException("Book is not available for loan");
        }

        return _bookLoanRepository.Save(bookLoan);
    }

    public BookLoan ReturnBook(BookLoan bookLoan)
    {
        return _bookLoanRepository.Delete(bookLoan.Id);
    }

    public IEnumerable<Book> GetAllBooks()
    {
        var books = _bookRepository.FindAll();
        if (books == null)
        {
            throw new ArgumentException("No books found");
        }

        return books;
    }

    public IEnumerable<BookLoan> GetAllLoans()
    {
        var bookLoans = _bookLoanRepository.FindAll();
        if (bookLoans == null)
        {
            throw new ArgumentException("No book loans found");
        }

        return bookLoans;
    }

    public Book FindBookById(int id)
    {
        var book = _bookRepository.FindOne(id);
        if (book == null)
        {
            throw new ArgumentException("Book not found");
        }

        return book;
    }

    public BookLoan FindLoanById(int id)
    {
        var bookLoan = _bookLoanRepository.FindOne(id);
        if (bookLoan == null)
        {
            throw new ArgumentException("Book loan not found");
        }

        return bookLoan;
    }

    public IEnumerable<Book> FindBooksByAuthor(string author)
    {
        var books = _bookRepository.FindAllByAuthor(author);
        if (books == null)
        {
            throw new ArgumentException("No books found by this author");
        }

        return books;
    }

    public IEnumerable<Book> FindBooksByTitle(string title)
    {
        var books = _bookRepository.FindAllByTitle(title);
        if (books == null)
        {
            throw new ArgumentException("No books found with this title");
        }
        return books;
    }

    public IEnumerable<Book> FindBooksByTitleAndAuthor(string title, string author)
    {
        throw new NotImplementedException();
    }
}