using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using WebStore.Controllers;

using Assert = Xunit.Assert;

namespace WebStore.Tests.Controllers
{
    [TestClass]
    public class ErrorsControllerTests
    {
        [TestMethod]
        public void Error404_Returns_View()
        {
            var controller = new ErrorsController();

            var result = controller.Error404();

            Assert.IsType<ViewResult>(result);
        }

        [TestMethod]
        public void AccessDenied_Returns_View()
        {
            var controller = new ErrorsController();

            var result = controller.AccessDenied();

            Assert.IsType<ViewResult>(result);
        }
    }
}
