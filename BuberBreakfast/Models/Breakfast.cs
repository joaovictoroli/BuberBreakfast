namespace BuberBreakfast.Models;

public class Breakfast {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime StartDatimeTime { get; set; }
    public DateTime EndDateTime { get; set; }
    public DateTime LastModifiedDateTime { get; set; }    
    public List<string> Savory { get; set; }
    public List<string> Sweet { get; set;}

    public Breakfast(Guid id,
        string name,
        string description,
        DateTime startDateTime,
        DateTime endDateTime,
        DateTime lastModifiedDateTime,
        List<string> savory,
        List<string> sweet)
    {
        // enforce validation rules
        Id = id;
        Name = name;
        Description = description;
        StartDatimeTime = startDateTime;
        EndDateTime = endDateTime;
        LastModifiedDateTime = lastModifiedDateTime;
        Savory = savory;
        Sweet = sweet;
    }
}