namespace PetProject.ModelsDTO;

public class ContractDto
{
    public string Name { get; set; }
    public string No { get; set; }
    public DateTime Date { get; set; }
    public Guid ClientId { get; set; }
    public string Description { get; set; }
}