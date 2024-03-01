using AutoMapper;
using MediatR;
using MediatR.Wrappers;
using PetProject.Models;
using PetProject.ModelsDTO;

namespace PetProject.Handlers;

public class CreateClientRequest : IRequest<Client>
{
    public ClientDto clientDto { get; set; }

    public CreateClientRequest(ClientDto _clientDto)
    {
        clientDto = _clientDto;
    }
}

public class CreateClientHandler : IRequestHandler<CreateClientRequest, Client>
{
    private AppDbContext _context;
    private IMapper _mapper;
    
    public CreateClientHandler(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<Client> Handle(CreateClientRequest request, CancellationToken cancellationToken)
    {
        var client = new Client();
        client = _mapper.Map<Client>(request.clientDto);
        
        _context.Clients.Add(client);
        _context.SaveChanges();
        
        return client;
    }
}
