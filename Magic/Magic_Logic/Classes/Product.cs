using Magic_Interface.DTO;

namespace Magic_Logic.Classes
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public int Stock { get; set; }


        public Product(int id, string name, string color, int stock)
        {
            Id = id;
            Name = name;
            Color = color;
            Stock = stock;
        }

        public Product()
        {

        }
        public Product(ProductDTO dto)
        {
            Id = dto.Id;
            Name = dto.Name;
            Color = dto.Color;
            Stock = dto.Stock;
        }
        public ProductDTO GetDTO()
        {
            ProductDTO dto = new ProductDTO(Id, Name, Color, Stock);
            return dto;
        }

        public override string? ToString()
        {
            return Name;
        }
    }
}
