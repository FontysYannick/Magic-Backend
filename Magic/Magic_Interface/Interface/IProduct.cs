using Magic_Interface.DTO;

namespace Magic_Interface.Interface
{
    public interface IProduct
    {
        public List<ProductDTO> Getproducts();
        public void Create(ProductDTO product);
        public void Delete(int id);
        public void Update(ProductDTO product);
        public ProductDTO GetProductById(int id);
    }
}
