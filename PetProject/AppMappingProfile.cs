using AutoMapper;
using PetProject.Models;
using PetProject.ModelsDTO;

namespace PetProject;

public class AppMappingProfile : Profile
{
    public AppMappingProfile()
    {
        CreateMap<ClientDto, Client>();
        
    }
    
    
    
}