using Model.Utils;

namespace Model;

public class Book: Entity<int>
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Quantity { get; set; }

    public Book(int id, string title, string author, int quantity) : base(id)
    {
        Id = id;
        Title = title;
        Author = author;
        Quantity = quantity;
    }

    public override string ToString()
    {
        return $"Book[Id:{Id.ToString()} Title:{Title} Author:{Author} Quantity:{Quantity}] ";
    }
}