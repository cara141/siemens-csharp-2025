namespace Model.Utils;

public class Entity<ID>
{
    public ID? Id { get; set; }

    public Entity() 
    {
    }
    
    public Entity(ID? id)
    {
        Id = id;
    }

    public override bool Equals(object? obj)
    {
        if (obj is Entity<ID> entity)
        {
            return EqualityComparer<ID>.Default.Equals(Id, entity.Id);
        }
        return false;
    }

    public override string ToString()
    {
        return $"Entity[Id:{Id?.ToString()}] ";
    }
}