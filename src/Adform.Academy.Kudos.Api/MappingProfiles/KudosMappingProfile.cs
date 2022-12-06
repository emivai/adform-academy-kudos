using Adform.Academy.Core.Entities;
using Adform.Academy.Core.Extensions;
using Adform.Academy.Kudos.Api.Dtos;
using AutoMapper;

namespace Adform.Academy.Kudos.Api.MappingProfiles
{
    public class KudosMappingProfile : Profile
    {
        public KudosMappingProfile()
        {
            CreateMap<KudosEntity, KudosDto>().ForMember(dest => dest.Reason, input => input.MapFrom(i => i.Reason.ToDescriptionString()));
            CreateMap<KudosEntity, CreateKudosDto>().ReverseMap();
        }
    }
}
