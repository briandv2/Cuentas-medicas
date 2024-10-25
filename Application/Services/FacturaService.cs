using AutoMapper;
using Core.Dtos;
using Core.Entities;
using Core.Interfaces;


namespace Application.Services
{
    public class FacturaService : IFacturaService
    {
        private readonly IFacturaRepository facturaRepository;
        private readonly IMapper _mapper;

        public FacturaService(IFacturaRepository facturaRepository, IMapper mapper)
        {
            this.facturaRepository = facturaRepository;
            _mapper = mapper;
        }
        public async Task CrearFactura(FacturaDTO facturaFDto)
        {
            var factura = _mapper.Map<Factura>(facturaFDto);
            await facturaRepository.CrearFactura(factura);
        }
    }
}
