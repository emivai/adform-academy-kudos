using Adform.Academy.Core.Entities;
using Adform.Academy.Kudos.Api.Dtos;
using AutoMapper;

namespace Adform.Academy.Kudos.Api.MappingProfiles
{
    /// <summary>
    /// Mapping profile for employee
    /// </summary>
    public class EmployeeMappingProfile : Profile
    {
        /// <summary>
        /// Mapping profile for Employee to EmployeeDto conversion (works both ways)
        /// </summary>
        public EmployeeMappingProfile()
        {
            CreateMap<Employee, EmployeeDto>().ReverseMap();
        }
    }
}
