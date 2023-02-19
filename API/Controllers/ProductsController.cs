using System.Threading.Tasks;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repository;

        public ProductsController(IProductRepository repository)
            => _repository = repository;

        [HttpGet]
        public async Task<IActionResult> GetProducts()
            => Ok(await _repository.GetProductsAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
            => Ok(await _repository.GetProductByIdAsync(id));
    }
}