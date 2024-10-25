namespace Infraestructure.Repositories
{
    public class FacturaRepository : IFacturaRepository
    {
        private readonly ProyectoGlosasContext _context;   
        public FacturaRepository(ProyectoGlosasContext context) {
            _context = context;
        }
        public async Task CrearFactura(Factura factura)
        {
            if (factura == null)
            {
                throw new ArgumentNullException(nameof(factura));
            }

            await _context.Facturas.AddAsync(factura);
            await _context.SaveChangesAsync();
        }
    }
}
