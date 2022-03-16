using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq;
using System.Collections.Generic;

namespace DataAccess.Concrete.EntityFrameworkDal
{

    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal
    {
        public List<ProductDetailDTO> GetProductDetails()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from p in context.Products
                             join c in context.Categories
                             on p.CategoryId equals c.CategoryId
                             select new ProductDetailDTO
                             {
                                 ProductId = p.ProductId
                           ,
                                 ProductName = p.ProductName,
                                 CategoryName = c.CategoryName
                           ,
                                 UnitsInStock = p.UnitsInStock
                             };
                return result.ToList();
            }
        }
    }

}