using NUnit.Framework;
using Moq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Dtos;
using Core.Entities;
using Core.Interfaces;
using Application.Services;

namespace Application.Tests
{
    [TestFixture]
    public class FacturaServiceTests
    {
        private Mock<IFacturaRepository> _facturaRepositoryMock;
        private Mock<IMapper> _mapperMock;
        private FacturaService _facturaService;

        [SetUp]
        public void SetUp()
        {
            _facturaRepositoryMock = new Mock<IFacturaRepository>();
            _mapperMock = new Mock<IMapper>();
            _facturaService = new FacturaService(_facturaRepositoryMock.Object, _mapperMock.Object);
        }

        [Test]
        public async Task CrearFactura_ShouldCallRepositoryWithMappedFactura()
        {
            // Arrange
            var facturaDto = new FacturaDTO { FacturaId = 1, NumeroFactura = "12345" };
            var factura = new Factura { FacturaId = 1, NumeroFactura = "12345" };

            _mapperMock.Setup(m => m.Map<Factura>(facturaDto)).Returns(factura);

            // Act
            await _facturaService.CrearFactura(facturaDto);

            // Assert
            _mapperMock.Verify(m => m.Map<Factura>(facturaDto), Times.Once);
            _facturaRepositoryMock.Verify(r => r.CrearFactura(factura), Times.Once);
        }
    }
}