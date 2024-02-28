namespace PetProject.Models;

public class Client : BaseDbItem
{
    public string Name { get; set; }
    public string Pass { get; set; } 
    public string Licence { get; set; }
    public List<Guid>? Contracts { get; set; }
}
    