using Magic_Interface.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic_Logic.Classes
{
    public class Cart
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public List<Product> productDTOs = new List<Product>();

        public Cart() { }

        public Cart(int id, int user)
        {
            this.Id = id;
            this.UserId = user;
        }

        public Cart(CartDTO dto)
        { 
            this.Id = dto.Id;
            this.UserId = dto.UserId;
        }

        public CartDTO GetDTO()
        {
            CartDTO dto = new CartDTO(Id, UserId);
            return dto;
        }
    }
}
