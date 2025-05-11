using Model;

namespace Persistence.Repository;

public interface IBookLoanRepository: IRepository<int, BookLoan>
{
    public int GetNumberOfBooksLoaned(int bookId);
}