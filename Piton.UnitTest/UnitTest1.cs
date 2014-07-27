using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Piton.Domain;
using Piton.Domain.Entities;
using Piton.Domain.Abstract;
using Moq;
using Piton.Domain.Concrete;
using Piton.WebUI.Controllers;
using Piton.WebUI.Models;
using Piton.WebUI.HtmlHelpers;

namespace Piton.UnitTest
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void Can_Pageinate()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new List<Product>
            {
                new Product { Name = "Item1", Price = 25 },
                new Product { Name = "Item2", Price = 45 },
                new Product { Name = "Item3", Price = 655 },
                new Product { Name = "Item4", Price = 655 },
                new Product { Name = "Item5", Price = 635 }
            }.AsQueryable());

            ProductController controller = new ProductController(mock.Object);

            controller.PageSize = 1;
            //act
            ProductListViewModel result = (ProductListViewModel)controller.List(2).Model;
            //assert
            PagingInfo pageInfo = result.PagingInfo;
            Assert.AreEqual(pageInfo.CurrentPage, 2);
            Assert.AreEqual(pageInfo.ItemsPerPage, 1);
            Assert.AreEqual(pageInfo.TotalItems, 5);
            /*
            Assert.IsTrue(prodArray.Length == 2);
            Assert.AreEqual(prodArray[0].Name, "Item4");
            Assert.AreEqual(prodArray[1].Name, "Item5");
             * */

        }

        [TestMethod]
        public void Can_Generate_Page_Links()
        {/*
            // Arrange - define an HTML helper - we need to do this 
            // in order to apply the extension method 
            HtmlHelper myHelper = null;
            // Arrange - create PagingInfo data 
            PagingInfo pagingInfo = new PagingInfo
            {
                CurrentPage = 2,
                TotalItems = 28,
                ItemsPerPage = 10
            };
            // Arrange - set up the delegate using a lambda expression 
            Func<int, string> pageUrlDelegate = i => "Page" + i;
            // Act 
            MvcHtmlString result = myHelper.PageLinks(pagingInfo, pageUrlDelegate);
            // Assert 
            Assert.AreEqual(result.ToString(), @"<a href=""Page1"">1</a>"
            + @"<a class=""selected"" href=""Page2"">2</a>"
            + @"<a href=""Page3"">3</a>");*/
        }

        [TestClass]
        public class AdminTests
        {
            [TestMethod]
            public void Index_Contains_All_Products()
            {
                // Arrange - create the mock repository 
                Mock<IProductRepository> mock = new Mock<IProductRepository>();
                mock.Setup(m => m.Products).Returns(new Product[] { 
            new Product {ProductID = 1, Name = "P1"}, 
            new Product {ProductID = 2, Name = "P2"}, 
            new Product {ProductID = 3, Name = "P3"}, 
            }.AsQueryable());
                // Arrange - create a controller 
                AdminController target = new AdminController(mock.Object);
                // Action 
                Product[] result = ((IEnumerable<Product>) ((ViewResult)target.Index()).ViewData.Model).ToArray();
                // Assert 
                Assert.AreEqual(result.Length, 3);
                Assert.AreEqual("P1", result[0].Name);
                Assert.AreEqual("P2", result[1].Name);
                Assert.AreEqual("P3", result[2].Name);
            }
        }
    }
}
