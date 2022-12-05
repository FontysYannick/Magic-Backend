using Magic_Interface.DTO;
using Magic_Interface.Interface;
using Magic_Logic.Classes;

namespace Magic_Logic.Container
{
    public class Product_Container
    {
        private readonly IProduct container;

        public Product_Container(IProduct container)
        {
            this.container = container;
        }


        public List<Product> Getproducts()
        {
            List<ProductDTO> dtos = container.Getproducts();
            List<Product> products = new List<Product>();
            foreach (ProductDTO dto in dtos)
            {
                products.Add(new Product(dto));
            }
            return products;
        }

        public void Create(Product p)
        {
            ProductDTO product = p.GetDTO();
            container.Create(product);
        }

        public void Delete(int ID)
        {
            container.Delete(ID);
        }

        public void Update(Product p)
        {
            ProductDTO product = p.GetDTO();
            container.Update(product);
        }

        public Product? GetProductById(int id)
        {
            ProductDTO? dto = container.GetProductById(id);
            return new Product(dto);
        }
    }
}
