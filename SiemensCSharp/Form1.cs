using System.Data;
using Model;
using Service;

namespace SiemensCSharp;

public partial class Form1 : Form
{
    public IService Service;
    private DataSet _libraryDataSet;

    public Form1()
    {
        InitializeComponent();
    }

    public void InitializeDataGrid()
    {
        InitializeModel();
        LoadBooks();
        LoadLoans();
        ColorIfAvailable();
    }

    private void InitializeModel()
    {
        _libraryDataSet = new DataSet();
        var booksTable = new DataTable("Books");
        booksTable.Columns.Add("Id", typeof(int));
        booksTable.Columns.Add("Title", typeof(string));
        booksTable.Columns.Add("Author", typeof(string));
        booksTable.Columns.Add("Quantity", typeof(int));
        _libraryDataSet.Tables.Add(booksTable);
        
        var loansTable = new DataTable("Loans");
        loansTable.Columns.Add("Id", typeof(int));
        loansTable.Columns.Add("BookId", typeof(int));
        loansTable.Columns.Add("LoanDate", typeof(DateTime));
        loansTable.Columns.Add("ReturnDate", typeof(DateTime));
        _libraryDataSet.Tables.Add(loansTable);
        
        BookGridView.DataSource = _libraryDataSet.Tables["Books"];
        BookGridView.Columns["Id"].Visible = false;
        
        BookLoanGridView.DataSource = _libraryDataSet.Tables["Loans"];
        BookLoanGridView.Columns["Id"].Visible = false;
    }

    private void LoadBooks()
    {
        var books = Service.GetAllBooks();
        _libraryDataSet.Tables["Books"].Clear();
        foreach (var book in books)
        {
            var row = _libraryDataSet.Tables["Books"].NewRow();
            row["Id"] = book.Id;
            row["Title"] = book.Title;
            row["Author"] = book.Author;
            row["Quantity"] = book.Quantity;
            _libraryDataSet.Tables["Books"].Rows.Add(row);
        }
    }
    
    private void LoadLoans()
    {
        var loans = Service.GetAllLoans();
        _libraryDataSet.Tables["Loans"].Clear();
        foreach (var loan in loans)
        {
            var row = _libraryDataSet.Tables["Loans"].NewRow();
            row["Id"] = loan.Id;
            row["BookId"] = loan.BookId;
            row["LoanDate"] = loan.LoanDate;
            row["ReturnDate"] = loan.ReturnDate;
            _libraryDataSet.Tables["Loans"].Rows.Add(row);
        }
    }

    private void AuthorTextBox_TextChanged(object sender, EventArgs e)
    {
        bool AuthorTextBoxEmpty = string.IsNullOrEmpty(AuthorTextBox.Text);
        bool TitleTextBoxEmpty = string.IsNullOrEmpty(TitleTextBox.Text);
        
        if (AuthorTextBoxEmpty && TitleTextBoxEmpty)
        {
            LoadBooks();
        }
        else if (AuthorTextBoxEmpty && !TitleTextBoxEmpty)
        {
            var title = TitleTextBox.Text;
            var books = Service.FindBooksByTitle(title);
            _libraryDataSet.Tables["Books"].Clear();
            foreach (var book in books)
            {
                var row = _libraryDataSet.Tables["Books"].NewRow();
                row["Id"] = book.Id;
                row["Title"] = book.Title;
                row["Author"] = book.Author;
                row["Quantity"] = book.Quantity;
                _libraryDataSet.Tables["Books"].Rows.Add(row);
            }
        } else if (!AuthorTextBoxEmpty && !TitleTextBoxEmpty)
        {
            var title = TitleTextBox.Text;
            var author = AuthorTextBox.Text;
            var books = Service.FindBooksByTitleAndAuthor(title, author);
            _libraryDataSet.Tables["Books"].Clear();
            foreach (var book in books)
            {
                var row = _libraryDataSet.Tables["Books"].NewRow();
                row["Id"] = book.Id;
                row["Title"] = book.Title;
                row["Author"] = book.Author;
                row["Quantity"] = book.Quantity;
                _libraryDataSet.Tables["Books"].Rows.Add(row);
            }
        }
        else
        {
            var author = AuthorTextBox.Text;
            var books = Service.FindBooksByAuthor(author);
            _libraryDataSet.Tables["Books"].Clear();
            foreach (var book in books)
            {
                var row = _libraryDataSet.Tables["Books"].NewRow();
                row["Id"] = book.Id;
                row["Title"] = book.Title;
                row["Author"] = book.Author;
                row["Quantity"] = book.Quantity;
                _libraryDataSet.Tables["Books"].Rows.Add(row);
            }
        }
    }
    
    private void TitleTextBox_TextChanged(object sender, EventArgs e)
    {
        AuthorTextBox_TextChanged(sender, e);
    }

    private void ColorIfAvailable()
    {
        foreach (DataGridViewRow row in BookGridView.Rows)
        {
            if (row.IsNewRow) continue; // Skip the "new row" if editing is enabled
        
            int bookId = (int)row.Cells["Id"].Value;
            int quantity = (int)row.Cells["Quantity"].Value;
        
            int availableBooks = Service.GetNumberOfAvailableBooks(bookId);
            if (availableBooks > 0)
            {
                row.DefaultCellStyle.BackColor = Color.LightGreen; // Available
            }
            else
            {
                row.DefaultCellStyle.BackColor = Color.Red; // Not available
            }
        }
    }
    
    private void LoanBookButton_Click(object sender, EventArgs e)
    {
        if (BookGridView.SelectedRows.Count == 0)
        {
            MessageBox.Show("Please select a book to loan.");
            return;
        }
        
        var selectedRow = BookGridView.SelectedRows[0];
        var bookId = (int)selectedRow.Cells["Id"].Value;
        var bookLoan = new BookLoan(0, bookId, DateTime.Now, DateTime.Now.AddDays(14));
        try
        {
            Service.LoanBook(bookLoan);
        } catch (Exception ex)
        {
            MessageBox.Show("Book is not available.");
            return;            
        }
        
        LoadLoans();
        ColorIfAvailable();
    }
    
    private void ReturnBookButton_Click(object sender, EventArgs e)
    {
        if (BookLoanGridView.SelectedRows.Count == 0)
        {
            MessageBox.Show("Please select a loan to return.");
            return;
        }
        
        var selectedRow = BookLoanGridView.SelectedRows[0];
        var loanId = (int)selectedRow.Cells["Id"].Value;
        var bookLoan = Service.FindLoanById(loanId);
        try
        {
            Service.ReturnBook(bookLoan);
        } catch (Exception ex)
        {
            MessageBox.Show("Too late to return the book.");
            return;
        }
        
        LoadLoans();
        ColorIfAvailable();
    }
}