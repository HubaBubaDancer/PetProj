using AutoMapper;
using PetProject.Handlers;
using PetProject.Models;
using PetProject.ModelsDTO;

namespace PetProject;

public class AppMappingProfile : Profile
{
    public AppMappingProfile()
    {
        CreateMap<ClientDto, Client>();
        CreateMap<CarDto, Car>();
    }
    
    
    
}