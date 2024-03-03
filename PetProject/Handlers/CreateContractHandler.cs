using AutoMapper;
using MediatR;
using PetProject.Models;
using PetProject.ModelsDTO;

namespace PetProject.Handlers;

public class CreateContractRequest : IRequest<Contract>
{
    public ContractDto contractDto { set; get; }

    public CreateContractRequest(ContractDto contractDto)
    {
        this.contractDto = contractDto;
    }
}


public class CreateContractHandler : IRequestHandler<CreateContractRequest, Contract>
{
    public AppDbContext _context { set; get; }
    public IMapper _mapper { set; get; }

    public CreateContractHandler(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Contract> Handle(CreateContractRequest request, CancellationToken cancellationToken)
    {
        var contract = new Contract();
        contract = _mapper.Map<Contract>(request.contractDto);
        _context.Contracts.Add(contract);
        _context.SaveChanges();
        return contract;
    }
}