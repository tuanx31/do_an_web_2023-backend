using web_api.Data;
using web_api.Models;
using web_api.Reponsitory.Abastract;

namespace web_api.Reponsitory.Implementation
{
    public class ProductService : IProductservice
    {
        private readonly MyDbContext _context;

        public ProductService(MyDbContext context) { 
        _context= context;
        }
        public List<HangHoaModel> GetAll(int s)
        {
            var AllProduct = _context.products.Where(hh => hh.id_category == s);
            var result = AllProduct.Select(hh => new HangHoaModel
            {
                name = hh.name,
                tenloai = hh.categories.name
            });
            return result.ToList();
        }
    }
}
