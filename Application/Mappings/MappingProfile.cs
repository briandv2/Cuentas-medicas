using AutoMapper;
using Core.Dtos;
using Core.Entities;

namespace Application.Mappings
{
    /// <summary>
    /// Profile for AutoMapper configurations.
    /// </summary>
    public class MappingProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MappingProfile"/> class.
        /// </summary>
        public MappingProfile()
        {
            CreateMap<FacturaDTO, Factura>().ReverseMap();
        }
    }
}