using Adform.Academy.Core.Entities;
using Adform.Academy.Kudos.Api.Dtos;
using AutoMapper;

namespace Adform.Academy.Kudos.Api.MappingProfiles
{
    public class EmployeeMappingProfile : Profile
    {
        public EmployeeMappingProfile()
        {
            CreateMap<Employee, EmployeeDto>().ReverseMap();
        }
    }
}
