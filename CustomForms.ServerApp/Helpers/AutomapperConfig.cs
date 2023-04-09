using AutoMapper;
using CustomForms.Data;
using CustomForms.ServerApp.Dtos;

namespace CustomForms.ServerApp.AutoMapper
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<BlankForm, BlankFormDtoCreate>()
                .ForMember(dest => dest.FormFields, act => act.MapFrom(src => src.FormFields))
                .ReverseMap();

            CreateMap<FormInputFieldDefinition, FormInputFieldDefinitionDtoCreate>().ReverseMap();
        }
    }
}
