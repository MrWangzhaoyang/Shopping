using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shopping.Api.Models;

namespace Shopping.Api.Controllers
{
    //[EnableCors("any")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : BaseController
    {
        private ShoppingContext _context;
        private ILogger<ProductsController> _logger;
        public ProductsController(ShoppingContext context, ILogger<ProductsController> logger)
        {
            this._logger = logger;
            this._context = context;
        }

        /// <summary>
        /// 查询商品
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(_context.Products.ToList());
        }

        /// <summary>
        /// 添加商品
        /// </summary>
        /// <param name="product">商品</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddProducts(Product product)
        {
            await _context.AddAsync(product);

            await _context.SaveChangesAsync();

            return Ok();
        }

        /// <summary>
        /// 删除商品
        /// </summary>
        /// <param name="Id">商品ID</param>
        /// <returns></returns>
        [Route("delete/{Id}")]
        [HttpDelete]
        public async Task<IActionResult> AddProducts(int Id)
        {
            var product = await _context.Products.FindAsync(Id);

            _context.Remove(product);

            await _context.SaveChangesAsync();

            return Ok();
        }

    }
}
