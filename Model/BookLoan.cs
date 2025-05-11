using Model.Utils;

namespace Model;

public class BookLoan: Entity<int>
{
    public int BookId { get; set; }
    public DateTime LoanDate { get; set; }
    public DateTime ReturnDate { get; set; }
    
    public BookLoan(int id, int bookId, DateTime loanDate, DateTime returnDate) : base(id)
    {
        Id = id;
        BookId = bookId;
        LoanDate = loanDate;
        ReturnDate = returnDate;
    }

    public override string ToString()
    {
        return $"BookLoan[Id:{Id.ToString()} BookId:{BookId} LoanDate:{LoanDate.ToString("yyyy-MM-dd")} ReturnDate:{ReturnDate.ToString("yyyy-MM-dd")}] ";
    }
}