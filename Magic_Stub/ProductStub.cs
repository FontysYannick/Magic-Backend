using Magic_Interface.DTO;
using Magic_Interface.Interface;

namespace Magic_Stub
{
    public class ProductStub : IProduct
    {
        public List<ProductDTO> products { get; set; }

        public ProductStub()
        {
            this.products = new List<ProductDTO>()
            {
                new ProductDTO() {Id = 1, Name = "First", Color = "Blue", Stock = 21 },
                new ProductDTO() {Id = 2, Name = "Second", Color = "Red", Stock = 43 },
                new ProductDTO() {Id = 3, Name = "Thirth", Color = "Green", Stock = 81 }
            };
        }

        public void Create(ProductDTO product)
        {
            products.Add(product);
        }

        public void Delete(int id)
        {
            int i = 0;
            while (i < products.Count && products[i].Id != id)
            {
                i++;
            }

            if (i != products.Count)
            {
                products.Remove(products[i]);
            }
        }

        public ProductDTO GetProductById(int id)
        {
            ProductDTO D = default;

            int i = 0;
            while (i < products.Count && products[i].Id != id)
            {
                i++;
            }

            if (i != products.Count)
            {
                D = products[i];
            }
            return D;
        }

        public List<ProductDTO> Getproducts()
        {
            return products;
        }

        public void Update(ProductDTO product)
        {
            for (var i = 0; i < products.Count; i++)
            {
                if (products[i].Id == product.Id)
                {
                    (products[i]) = product;
                }
            }
        }
    }
}
