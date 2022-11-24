using Magic_DAL.Context;
using Magic_Interface.DTO;
using Magic_Logic.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Magic_Test
{
    [TestClass]
    public class ProductTest
    {
        [TestMethod]
        public void TestGetProductsFirstProductAndCount()
        {
            Product_Context testproduct = new Product_Context("Server=mssqlstud.fhict.local;Database=dbi485841_magic;User Id=dbi485841_magic;Password=Welkom01;");

            //Arrange
            Product p1 = new Product(1, "Schroef", "1", 34);
            Product p2 = new Product(2, "Bout", "1", 2);
            Product p3 = new Product(3, "Plug", "2", 23);
            Product p4 = new Product(4, "Boor", "2", 12);
            List<Product> products = new();
            products.Add(p1);
            products.Add(p2);
            products.Add(p3);
            products.Add(p4);

            //Act
            List<ProductDTO> products2 = testproduct.Getproducts();
            List<Product> newproducts = new();

            foreach (ProductDTO product in products2)
            {
                Product newproduct = new Product(product);
                newproducts.Add(newproduct);
            }


            //Assert
            Assert.AreEqual(products[0].Name, newproducts[0].Name);
            Assert.AreEqual(products.Count, newproducts.Count);
        }

        /*        [TestMethod]
                public void TestCreateUser()
                {
                    ProductMSSQL testproduct = new ProductMSSQL("Server=mssqlstud.fhict.local;Database=dbi485146_AXI;User Id=dbi485146_AXI;Password=Welkom01;");

                    //Arrange
                    Product p1 = new Product(1, "Schroef", "A1", 34, 5, 5);

                    //Act
                    Product CreatedProduct = new Product(testproduct.Create(new ProductDTO(2, "Boor", "A2", 12, 5, 5)));

                    //Assert
                    Assert.AreEqual(p1.ProductGroup, CreatedProduct.ProductGroup);
                }*/

        [TestMethod]
        public void TestGetProductById()
        {
            Product_Context testproduct = new Product_Context("Server=mssqlstud.fhict.local;Database=dbi485841_magic;User Id=dbi485841_magic;Password=Welkom01;");
            //Arrange
            Product p1 = new Product(1, "Schroef", "1", 34);

            //Act
            Product searchedProduct = new Product(testproduct.GetProductById(1));

            //Assert
            Assert.AreEqual(p1.Name, searchedProduct.Name);
        }
    }
}
