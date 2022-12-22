using Magic_Interface.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic_Interface.Interface
{
    public interface ICart
    {
        public CartDTO GetCart(int user);
        public void Create(ProductDTO product, int user);
        public void Delete(int id);
        public void Update(ProductDTO product, int user);
        public List<ProductDTO> GetProductsFromCart(int id);
    }
}
