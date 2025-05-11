using Microsoft.Data.Sqlite;
using Model;

namespace Persistence.Repository;

public class BookLoanRepository: IBookLoanRepository
{
    private readonly string _connectionString;
    
    public BookLoanRepository(string connectionString)
    {
        _connectionString = connectionString;
    }
    
    private SqliteConnection GetConnection()
    {
        var connection = new SqliteConnection(_connectionString);
        connection.Open();
        return connection;
    }
    
    public BookLoan FindOne(int id)
    {
        var connection = GetConnection();
        try
        {
            string query = "SELECT * FROM book_loans WHERE id = @id";
            using (var command = new SqliteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@id", id);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new BookLoan(id,
                            reader.GetInt32(1), // bookId
                            DateTime.Parse(reader.GetString(2)), // loanDate
                            DateTime.Parse(reader.GetString(3)) // returnDate
                        );
                    }
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        finally
        {
            connection.Close();
        }
        return null;
    }

    public IEnumerable<BookLoan> FindAll()
    {
        var connection = GetConnection();
        var bookLoans = new List<BookLoan>();
        try
        {
            string query = "SELECT * FROM book_loans";
            using (var command = new SqliteCommand(query, connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        bookLoans.Add(new BookLoan(reader.GetInt32(0),
                            reader.GetInt32(1), // bookId
                            DateTime.Parse(reader.GetString(2)), // loanDate
                            DateTime.Parse(reader.GetString(3)) // returnDate
                        ));
                    }
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        finally
        {
            connection.Close();
        }
        return bookLoans;
    }

    public BookLoan Save(BookLoan entity)
    {
        var connection = GetConnection();
        try
        {
            string query =
                "INSERT INTO book_loans (book_id, loan_date, return_date) VALUES (@bookId, @loanDate, @returnDate)";
            using (var command = new SqliteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@bookId", entity.BookId);
                command.Parameters.AddWithValue("@loanDate", entity.LoanDate.ToString("yyyy-MM-dd"));
                command.Parameters.AddWithValue("@returnDate", entity.ReturnDate.ToString("yyyy-MM-dd"));
                command.ExecuteNonQuery();
            }

            string selectQuery = "SELECT last_insert_rowid()";
            using (var command = new SqliteCommand(selectQuery, connection))
            {
                entity.Id = (int)(long)command.ExecuteScalar();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
        finally
        {
            connection.Close();
        }
        return entity;
    }

    public BookLoan Delete(int id)
    {
        var connection = GetConnection();
        try
        {
            string query = "DELETE FROM book_loans WHERE id = @id";
            using (var command = new SqliteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
        finally
        {
            connection.Close();
        }
        return null;
    }

    public BookLoan Update(BookLoan entity)
    {
        var connection = GetConnection();
        try
        {
            string query =
                "UPDATE book_loans SET book_id = @bookId, loan_date = @loanDate, return_date = @returnDate WHERE id = @id";
            using (var command = new SqliteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@id", entity.Id);
                command.Parameters.AddWithValue("@bookId", entity.BookId);
                command.Parameters.AddWithValue("@loanDate", entity.LoanDate.ToString("yyyy-MM-dd"));
                command.Parameters.AddWithValue("@returnDate", entity.ReturnDate.ToString("yyyy-MM-dd"));
                command.ExecuteNonQuery();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
        finally
        {
            connection.Close();
        }
        return entity;
    }

    public int GetNumberOfBooksLoaned(int bookId)
    {
        var connection = GetConnection();
        try
        {
            string query = "SELECT COUNT(*) FROM book_loans WHERE book_id = @bookId AND return_date IS NULL";
            using (var command = new SqliteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@bookId", bookId);
                return Convert.ToInt32(command.ExecuteScalar());
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
        finally
        {
            connection.Close();
        }
    }
}