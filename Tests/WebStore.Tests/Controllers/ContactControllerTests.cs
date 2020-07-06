using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using WebStore.Controllers;

using Assert = Xunit.Assert;

namespace WebStore.Tests.Controllers
{
    [TestClass]
    public class ContactControllerTests
    {
        [TestMethod]
        public void ContactUs_Returns_View()
        {
            var controller = new ContactController();

            var result = controller.Index();

            Assert.IsType<ViewResult>(result);
        }
    }
}