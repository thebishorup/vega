using AutoMapper;
using vega.Model;
using vega.ViewModel;
using Vega.Model;
using Vega.ViewModel;
using System.Linq;
using System.Collections.Generic;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        //Domain to API ViewModel
        CreateMap<Photo, PhotoViewModel>();
        CreateMap(typeof(QueryResult<>), typeof(QueryResultViewModel<>));
        CreateMap<Make, MakeViewModel>();
        CreateMap<Modle, KeyValuePairViewModel>();
        CreateMap<Make, KeyValuePairViewModel>();
        CreateMap<Feature, KeyValuePairViewModel>();
        CreateMap<Vehicle, SaveVehicleViewModel>()
            .ForMember(vr => vr.Contact, opt => opt.MapFrom(v => new ContactViewModel { Name = v.ContactName, Email = v.ContactEmail, Phone = v.ContactPhone }))
            .ForMember(vr => vr.Features, opt => opt.MapFrom(v => v.Features.Select(vf => vf.FeatureId)));
        CreateMap<Vehicle, VehicleViewModel>()
            .ForMember(vr => vr.Make, opt => opt.MapFrom(v => v.Model.Make))
            .ForMember(vr => vr.Contact, opt => opt.MapFrom(v => new ContactViewModel { Name = v.ContactName, Email = v.ContactEmail, Phone = v.ContactPhone }))
            .ForMember(vr => vr.Features, opt => opt.MapFrom(v => v.Features.Select(vf => new KeyValuePairViewModel { Id = vf.FeatureId, Name = vf.Feature.Name })));

        //API ViewModel to Domain Model
        CreateMap<VehicleQueryViewModel, VehicleQuery>();
        CreateMap<SaveVehicleViewModel, Vehicle>()
            .ForMember(v => v.Id, opt => opt.Ignore())
            .ForMember(v => v.ContactName, opt => opt.MapFrom(vr => vr.Contact.Name))
            .ForMember(v => v.ContactEmail, opt => opt.MapFrom(vr => vr.Contact.Email))
            .ForMember(v => v.ContactPhone, opt => opt.MapFrom(vr => vr.Contact.Phone))
            .ForMember(v => v.Features, opt => opt.Ignore())
            .AfterMap((vr, v) => {
                //Remove unselected features
                var removedFeatures = new List<VehicleFeature>();
                foreach(var f in v.Features)
                    if(!vr.Features.Contains(f.FeatureId))
                        removedFeatures.Add(f);
                
                foreach(var f in removedFeatures)
                    v.Features.Remove(f);

                /* Using Linq (Alternative): Start */
                // var removedF = v.Features.Where(f => !vr.Features.Contains(f.FeatureId));
                // foreach(var f in removedF)
                //     v.Features.Remove(f);
                /* Using Linq (Alternative): End */

                //Add selected new features
                //foreach(var id in vr.Features)
                //    if(!v.Features.Any(f => f.FeatureId == id))
                //        v.Features.Add(new VehicleFeature { FeatureId = id });

                /* Using Linq (Alternative): Start */
                var addedF = vr.Features.Where(id => !v.Features.Any(f => f.FeatureId == id));
                foreach (var id in addedF)
                    v.Features.Add(new VehicleFeature { FeatureId = id });
                /* Using Linq (Alternative): End */
            });
    }
}