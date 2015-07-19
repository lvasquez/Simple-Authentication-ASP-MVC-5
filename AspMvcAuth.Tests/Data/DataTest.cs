using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AspMvcAuth.Models;
using AspMvcAuth.Data;

namespace AspMvcAuth.Tests.Data
{
    /// <summary>
    /// Summary description for DataTest
    /// </summary>
    [TestClass]
    public class DataTest
    {

        [TestMethod]
        public void GetUsers_Return_NotNull()
        {

            var _controller = new DomainData();

            var result = _controller.getUsers();

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IEnumerable<User>));
        }
    }
}
