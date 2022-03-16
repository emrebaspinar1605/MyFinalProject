using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController] //ATTRIBUTE 
    public class ProductsController : ControllerBase
    {
        //Loosely coupled *gevşek bağlılık(soyuta bağlılık)
        //naming convention *isimlendirme kuralları
        //IoC Container -- Inversion of Control
        IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet("getbyid")]
        public IActionResult Get(int id)
        {
            var result = _productService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getall")]
        public IActionResult Get()
        {
            //Swagger
            //Dependency chain
            var result = _productService.GetAll();
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }

        //public List<Product> Get()
        //   {


        //      IProductService productService = new ProductManager(new EfProductDal());
        //      var result= productService.GetAll();
        //      return result.Data;
        //     var result =_productService.GetAll();
        //    return result.Data;
        //}
        [HttpPost("add")]
        public IActionResult Post(Product product)
        {
            var result = _productService.Add(product);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }
    }
}