using Magic_Interface.DTO;

namespace Magic_Interface.Interface
{
    public interface ICart
    {
        public CartDTO GetCart(int user);
        public void Create(ProductDTO product, int user);
        public void Delete(ProductDTO product, int user);
        public void Update(ProductDTO product, int user);
        public List<ProductDTO> GetProductsFromCart(int id);
    }
}
