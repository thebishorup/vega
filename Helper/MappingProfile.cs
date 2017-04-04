using AutoMapper;
using Vega.Model;
using Vega.ViewModel;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Make, MakeViewModel>();
        CreateMap<Modle, ModelViewModel>();
    }
}