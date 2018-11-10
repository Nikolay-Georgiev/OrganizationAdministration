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
    public class CompaniesControllerTest
    {

        [TestMethod]
        public void TestDetailsView()
        {
            var companiesController = new CompaniesController();
            var result = companiesController.Details(1) as ViewResult;
            Assert.AreEqual("Details", result.ViewName);

        }

    }
}
