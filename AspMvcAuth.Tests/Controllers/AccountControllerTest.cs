using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AspMvcAuth.Controllers;
using System.Web.Mvc;
using AspMvcAuth.Models;
using Microsoft.Owin.Security;
using Moq;
using AspMvcAuth.Repositories;

namespace AspMvcAuth.Tests.Controllers
{
    /// <summary>
    /// Summary description for AccountControllerTest
    /// </summary>
    [TestClass]
    public class AccountControllerTest
    {

        private Mock<IAuthenticationManager> _mockService; // dependency of controller
        private Mock<IAccount> _mockAccount;
        private AccountController _controller;

        [TestInitialize]
        public void Setup()
        {
            _mockService = new Mock<IAuthenticationManager>();
            _mockAccount = new Mock<IAccount>();
            _controller = new AccountController(_mockService.Object, _mockAccount.Object);
        }


        [TestMethod]
        public void Login_Return_NotNull()
        {

            string error = "error";

            var result = _controller.Login(error);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }


        [TestMethod]
        public void Login_Post_Return_NotNull()
        {
            LoginViewModel model = new LoginViewModel() { UserName = "luis-vasquez", Password = "12345" };
            
            IList<User> users = new List<User>();
            users.Add(new User() { Id = 1, userName = "luis-vasquez", password = "12345", status = true });
            users.Add(new User() { Id = 2, userName = "invite", password = "12345", status = false });

            _mockAccount.Setup(a => a.getUsers()).Returns(users);

            var result = _controller.Login(model);
            var rresult = (RedirectToRouteResult)result;

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
            Assert.AreEqual(rresult.RouteValues["action"], "Index");
            Assert.AreEqual(rresult.RouteValues["controller"], "Home");

        }

        [TestMethod]
        public void Login_Post_Return_InValidModel()
        {
            LoginViewModel model = new LoginViewModel() { UserName = "admin", Password = "12345" };

            _controller.ModelState.AddModelError("", "Invalid Model");

            var result = _controller.Login(model);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void Login_Post_Return_InValidUser()
        {
            LoginViewModel model = new LoginViewModel() { UserName = "Admin", Password = "12345" };

            var result = _controller.Login(model);
            var rresult = (ViewResult)result;

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            Assert.IsInstanceOfType(rresult.Model, typeof(LoginViewModel));
        }

        [TestMethod]
        public void Logoff_Return_NotNull()
        {
            var result = _controller.LogOff();

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
        }
    }
}
