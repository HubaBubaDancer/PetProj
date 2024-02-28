using Microsoft.AspNetCore.Mvc;
using PetProject.Models;

namespace PetProject.Controllers;

[Controller]
public class ContractController : Controller
{
    
    public AppDbContext _context { get; set; }

    public ContractController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult Client()
    {
        var responce = new ObjectResult(new Client
        {
            Name = "TestName", Licence = "Test",
            Pass = "TestPass"
        });

        _context.Add(responce);
        _context.SaveChanges();
        
        return responce;
    }
}