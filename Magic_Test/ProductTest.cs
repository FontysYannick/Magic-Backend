using Magic_DAL.Context;
using Magic_Interface.DTO;
using Magic_Logic.Classes;
using Magic_Logic.Container;
using Magic_Stub;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Magic_Test
{
    [TestClass]
    public class ProductTest
    {
        [TestMethod]
        public void TestAddProduct()
        {
            //Arrange
            Product product = new Product(4, "fourth", "Black", 5);
            ProductStub stub = new ProductStub();
            List<Product> products = new List<Product>();
            Product_Container container = new Product_Container(stub);

            //Act
            container.Create(product);
            products = container.Getproducts();

            //Assert
            Assert.IsNotNull(products);
            Assert.AreEqual(4, products.Count);
            Assert.AreEqual("fourth", products[3].Name);
        }

        [TestMethod]
        public void TestDeleteProduct()
        {
            //Arrange
            ProductStub stub = new ProductStub();
            List<Product> products = new List<Product>();
            Product_Container container = new Product_Container(stub);

            //Act
            container.Delete(3);
            products = container.Getproducts();

            //Assert
            Assert.IsNotNull(products);
            Assert.AreEqual(2, products.Count);
            Assert.ThrowsException<NullReferenceException>(() => container.GetProductById(3));
        }

        [TestMethod]
        public void TestUpdateProduct()
        {
            //Arrange
            Product product = new Product(3, "fourth", "Black", 5);
            ProductStub stub = new ProductStub();
            List<Product> products = new List<Product>();
            Product_Container container = new Product_Container(stub);

            //Act
            container.Update(product);
            products = container.Getproducts();

            //Assert
            Assert.IsNotNull(products);
            Assert.AreEqual(3, products.Count);
            Assert.AreEqual("fourth", products[2].Name);
        }

        [TestMethod]
        public void TestGetProducts()
        {
            //Arrange
            ProductStub stub = new ProductStub();
            List<Product> products = new List<Product>();
            Product_Container container = new Product_Container(stub);

            //Act
            products = container.Getproducts();

            //Assert
            Assert.IsNotNull(products);
            Assert.AreEqual(3, products.Count);
        }

        [TestMethod]
        public void TestGetProductById()
        {
            //Arrange
            Product products = new Product();
            ProductStub stub = new ProductStub();
            Product_Container container = new Product_Container(stub);

            //Act
            products = container.GetProductById(1);

            //Assert
            Assert.IsNotNull(products);
            Assert.AreEqual("First", products.Name);
            Assert.AreEqual("Blue", products.Color);
            Assert.AreEqual(21, products.Stock);
        }
    }
}
