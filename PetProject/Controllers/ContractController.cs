using MediatR;
using Microsoft.AspNetCore.Mvc;
using PetProject.Handlers;
using PetProject.Models;
using PetProject.ModelsDTO;

namespace PetProject.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class ContractController : Controller
{
    private readonly IMediator _mediator;
    public AppDbContext _context { get; set; }

    public ContractController(AppDbContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
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

    [HttpPost("ProperWay")]
    public async Task<Client> CreateClientTwo([FromBody] ClientDto clientDto)
    {
        var client = _mediator.Send(new CreateClientRequest(clientDto)).Result;
        return client;
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

    [HttpPost]
    public async Task<Car> CreateCar([FromBody] CarDto carDto)
    {
        var car = _mediator.Send(new CreateCarRequest(carDto)).Result;
        return car;
    }

    [HttpPost]
        public async Task<Contract> CreateContract([FromBody] ContractDto contractDto)
        {
            var contract = _mediator.Send(new CreateContractRequest(contractDto)).Result;
            return contract;
        }
    
    

}