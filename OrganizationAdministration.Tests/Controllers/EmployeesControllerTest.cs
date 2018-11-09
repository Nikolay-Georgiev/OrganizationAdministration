using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrganizationAdministration.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OrganizationAdministration.Tests.Controllers
{
    [TestClass]
    public class EmployeesControllerTest
    {
        [TestMethod]
        public void TestDetailsView()
        {
            var employeesCorntorller = new EmployeesController();
            var result = employeesCorntorller.Details(1) as ViewResult;
            Assert.AreEqual("Details", result.ViewName);

        }

        [TestMethod]
        public void TestIndexView()
        {
            var employeesCorntorller = new EmployeesController();
            var result = employeesCorntorller.Index() as ViewResult;
            Assert.AreEqual("Index", result.ViewName);

        }
        [TestMethod]
        public void TestEditView()
        {
            var employeesCorntorller = new EmployeesController();
            var result = employeesCorntorller.Edit(1) as ViewResult;
            Assert.AreEqual("Edit", result.ViewName);

        }

        [TestMethod]
        public void TestCreateView()
        {
            var employeesCorntorller = new EmployeesController();
            var result = employeesCorntorller.Create() as ViewResult;
            Assert.AreEqual("Create", result.ViewName);

        }

        [TestMethod]
        public void TestDeleteView()
        {
            var employeesCorntorller = new EmployeesController();
            var result = employeesCorntorller.Delete(1) as ViewResult;
            Assert.AreEqual("Delete", result.ViewName);

        }
    }
}
