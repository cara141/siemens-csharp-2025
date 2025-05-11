using Microsoft.Data.Sqlite;
using Model;

namespace Persistence.Repository;

public class BookRepository :IBookRepository
{
    private readonly string _connectionString;
    
    public BookRepository(string connectionString)
    {
        _connectionString = connectionString;
    }
    
    public Book FindOne(int id)
    {
        var connection = new SqliteConnection(_connectionString);
        connection.Open();
        try
        {
            string query = "SELECT * FROM books WHERE id = @id";
            using (var command = new SqliteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@id", id);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Book(id,
                            reader.GetString(1), // title
                            reader.GetString(2), // author
                            reader.GetInt32(3) // year
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

    public IEnumerable<Book> FindAll()
    {
        var connection = new SqliteConnection(_connectionString);
        connection.Open();
        var books = new List<Book>();
        try
        {
            string query = "SELECT * FROM books";
            using (var command = new SqliteCommand(query, connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        books.Add(new Book(reader.GetInt32(0),
                            reader.GetString(1), // title
                            reader.GetString(2), // author
                            reader.GetInt32(3) // year
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
        return books;
    }

    public IEnumerable<Book> FindAllByAuthor(string author)
    {
        var connection = new SqliteConnection(_connectionString);
        connection.Open();
        var books = new List<Book>();
        try
        {
            string query = "SELECT * FROM books WHERE author = @author";
            using (var command = new SqliteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@author", author);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        books.Add(new Book(reader.GetInt32(0),
                            reader.GetString(1), // title
                            reader.GetString(2), // author
                            reader.GetInt32(3) // year
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
        return books;
    }

    public IEnumerable<Book> FindAllByTitle(string title)
    {
        var connection = new SqliteConnection(_connectionString);
        connection.Open();
        var books = new List<Book>();
        try
        {
            string query = "SELECT * FROM books WHERE title = @title";
            using (var command = new SqliteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@title", title);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        books.Add(new Book(reader.GetInt32(0),
                            reader.GetString(1), // title
                            reader.GetString(2), // author
                            reader.GetInt32(3) // year
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
        return books;
    }

    public IEnumerable<Book> FindAllByTitleAndAuthor(string title, string author)
    {
        var connection = new SqliteConnection(_connectionString);
        connection.Open();
        var books = new List<Book>();
        try
        {
            string query = "SELECT * FROM books WHERE title = @title AND author = @author";
            using (var command = new SqliteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@title", title);
                command.Parameters.AddWithValue("@author", author);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        books.Add(new Book(reader.GetInt32(0),
                            reader.GetString(1), // title
                            reader.GetString(2), // author
                            reader.GetInt32(3) // year
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
        return books;
    }

    public Book Save(Book entity)
    {
        throw new NotImplementedException();
    }

    public Book Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Book Update(Book entity)
    {
        throw new NotImplementedException();
    }
}