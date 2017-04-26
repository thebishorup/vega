using AutoMapper;
using vega.Model;
using vega.ViewModel;
using Vega.Model;
using Vega.ViewModel;
using System.Linq;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        //Domain to API ViewModel
        CreateMap<Make, MakeViewModel>();
        CreateMap<Modle, ModelViewModel>();
        CreateMap<Feature, FeatureViewModel>();
        CreateMap<Vehicle, VehicleViewModel>()
            .ForMember(vr => vr.Contact, opt => opt.MapFrom(v => new ContactViewModel { Name = v.ContactName, Email = v.ContactEmail, Phone = v.ContactPhone }))
            .ForMember(vr => vr.Features, opt => opt.MapFrom(v => v.Features.Select(vf => vf.FeatureId)));

        //API ViewModel to Domain Model
        CreateMap<VehicleViewModel, Vehicle>()
            .ForMember(v => v.ContactName, opt => opt.MapFrom(vr => vr.Contact.Name))
            .ForMember(v => v.ContactEmail, opt => opt.MapFrom(vr => vr.Contact.Email))
            .ForMember(v => v.ContactPhone, opt => opt.MapFrom(vr => vr.Contact.Phone))
            .ForMember(v => v.Features, opt => opt.MapFrom(vr => vr.Features.Select(id => new VehicleFeature { FeatureId = id })));
    }
}