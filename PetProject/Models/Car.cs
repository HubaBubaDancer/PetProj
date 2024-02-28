namespace PetProject.Models;

public class Car : BaseDbItem
{
    public string Name { get; set; }
    public string Description { get; set; }
    public Guid Contract { get; set; }
}