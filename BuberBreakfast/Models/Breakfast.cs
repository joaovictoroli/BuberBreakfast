using BuberBreakfast.Contracts.Breakfast;
using BuberBreakfast.ServicesErrors;
using ErrorOr;

namespace BuberBreakfast.Models;

public class Breakfast 
{
    public const int MinNameLength = 3;
    public const int MaxNameLength = 50;
    public const int MinDescriptionLength = 50;
    public const int MaxDescriptionLength = 150;
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime StartDatimeTime { get; set; }
    public DateTime EndDateTime { get; set; }
    public DateTime LastModifiedDateTime { get; set; }    
    public List<string> Savory { get; set; }
    public List<string> Sweet { get; set;}

    private Breakfast(Guid id,
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

    public static ErrorOr<Breakfast> Create(
        string name,
        string description,
        DateTime startDateTime,
        DateTime endDateTime,
        List<string> savory,
        List<string> sweet,
        Guid? id = null)
    {
        List<Error> errors = new ();
        if (name.Length is < MinNameLength or > MaxNameLength)
        {
            errors.Add(Errors.Breakfast.InvalidName);
        }

        if (description.Length is < MinDescriptionLength or > MaxDescriptionLength)
        {
            errors.Add(Errors.Breakfast.InvalidDescription);
        }

        if (errors.Any())
        {
            return errors;
        }

        return new Breakfast(
            id ?? Guid.NewGuid(),
            name: name,
            description: description,
            startDateTime: startDateTime,
            endDateTime: endDateTime,
            lastModifiedDateTime: DateTime.UtcNow,
            savory: savory,
            sweet: sweet);
    }

    public static ErrorOr<Breakfast> From(CreateBreakfastRequest request) 
    {
        return Create(
            name: request.Name,
            description: request.Description,
            startDateTime: request.StartDateTime,
            endDateTime: request.EndDateTime,
            savory: request.Savory,
            sweet: request.Sweet);
    }

    public static ErrorOr<Breakfast> From(Guid id, UpsertBreakfastRequest  request) 
    {
        return Create(
            name: request.Name,
            description: request.Description,
            startDateTime: request.StartDateTime,
            endDateTime: request.EndDateTime,
            savory: request.Savory,
            sweet: request.Sweet,
            id);
    }
}