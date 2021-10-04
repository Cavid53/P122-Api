using AutoMapper;
using FirstApi.DTO;
using FirstApi.Models;

namespace FirstApi.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeDTO>().ReverseMap();
        }
    }
}
