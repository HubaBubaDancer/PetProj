using AutoMapper;
using MediatR;
using PetProject.Models;
using PetProject.ModelsDTO;

namespace PetProject.Handlers;


public class CreateCarRequest : IRequest<Car>
{
    public CarDto carDto  {get; set;}

    public CreateCarRequest(CarDto carDto)
    {
        this.carDto = carDto;
    }
}


public class CreateCarHandler : IRequestHandler<CreateCarRequest, Car>
{
    private AppDbContext _context;
    private IMapper _mapper;

    public CreateCarHandler(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Car> Handle(CreateCarRequest request, CancellationToken cancellationToken)
    {
        var car = new Car();
        car = _mapper.Map<Car>(request.carDto);
        _context.Cars.Add(car);
        _context.SaveChanges();
        return car;
    }
}