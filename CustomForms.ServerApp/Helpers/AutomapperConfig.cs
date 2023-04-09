using AutoMapper;
using CustomForms.Data;
using CustomForms.ServerApp.Data;
using CustomForms.ServerApp.Dtos;

namespace CustomForms.ServerApp.AutoMapper
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<BlankForm, BlankFormDtoCreate>()
                .ForMember(dest => dest.FormFieldDtos,
                act => act.MapFrom(src => src.FormFields))
                .ReverseMap();

            CreateMap<FormInputFieldDefinition, FormInputFieldDefinitionDtoCreate>()
                .ReverseMap();

            CreateMap<Dispatch, DispatchDto>()
                .ForMember(dest => dest.BlankFormDto,
                act => act.MapFrom(src => src.BlankForm))
                .ReverseMap();

            //CreateMap<BlankForm, BlankFormDtoCreate>()
            //    .ForMember(dest => dest.FormFieldDtos,
            //    act => act.MapFrom(src => src.FormFields))
            //    .ReverseMap();
        }
    }
}
