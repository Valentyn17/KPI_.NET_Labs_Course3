using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using Web_API_app;
using Web_API_app.Controllers;

namespace Web_API_app.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Home Page", result.ViewBag.Title);
        }
    }
}
