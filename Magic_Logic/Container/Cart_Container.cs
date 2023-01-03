using Magic_Interface.DTO;
using Magic_Interface.Interface;
using Magic_Logic.Classes;

namespace Magic_Logic.Container
{
    public class Cart_Container
    {
        private readonly ICart container;

        public Cart_Container(ICart cart)
        {
            this.container = cart;
        }

        public Cart GetCart(int user)
        {
            return new Cart(container.GetCart(user));
        }

        public void Create(Product product, int user)
        {
            container.Create(product.GetDTO(), user);
        }

        public void Delete(Product product, int user)
        {
            container.Delete(product.GetDTO(), user);
        }

        public void Update(Product product, int user)
        {
            container.Update(product.GetDTO(), user);
        }

        public List<Product> GetProductsFromCart(int id)
        {
            List<ProductDTO> dtos = container.GetProductsFromCart(id);
            List<Product> products = new List<Product>();
            foreach (ProductDTO dto in dtos)
            {
                products.Add(new Product(dto));
            }
            return products;

        }
    }
}
