using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

using System.Collections.Generic;
using System.Linq;

using WebStore.Controllers;
using WebStore.Interfaces.TestApi;

using Assert = Xunit.Assert;

namespace WebStore.Tests.Controllers
{
    [TestClass]
    public class WebApiTestControllerTests
    {
        [TestMethod]
        public void Index_Returns_View_with_Values()
        {
            var expectedResult = new[] { "1", "2", "3" };

            var valueServiceMock = new Mock<IValueService>();
            valueServiceMock
                .Setup(service => service.Get())
                .Returns(expectedResult);

            var controller = new WebApiTestController(valueServiceMock.Object);

            var result = controller.Index();

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<string>>(viewResult.Model);

            Assert.Equal(expectedResult.Length, model.Count());

            valueServiceMock.Verify(service => service.Get());
            valueServiceMock.VerifyNoOtherCalls();
        }
    }
}