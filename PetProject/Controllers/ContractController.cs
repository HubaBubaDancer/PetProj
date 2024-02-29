using Microsoft.AspNetCore.Mvc;
using PetProject.Models;

namespace PetProject.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class ContractController : Controller
{
    
    public AppDbContext _context { get; set; }

    public ContractController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult CreateClient(string Name, string Licence, string Pass)
    {
        var responce = new Client
        {
            Name = Name, Licence = Licence,
            Pass = Pass
        };

        _context.Add(responce);
        _context.SaveChanges();
        
        return new ObjectResult(responce);
    }
    
    [HttpGet]
    public IActionResult GetClients()
    {
        var result = _context.Clients.ToList();
        return new ObjectResult(result);
    }

    [HttpDelete]
    public IActionResult DeleteClient(Guid id)
    {
        var result = _context.Clients.FirstOrDefault(c => c.id == id);

        _context.Remove(result);
        _context.SaveChanges();

        return new ObjectResult(result);
    }

}