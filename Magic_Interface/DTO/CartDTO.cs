namespace Magic_Interface.DTO
{
    public class CartDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public List<ProductDTO> productDTOs = new List<ProductDTO>();

        public CartDTO() { }

        public CartDTO(int id, int user)
        {
            this.Id = id;
            this.UserId = user;
        }

    }
}
