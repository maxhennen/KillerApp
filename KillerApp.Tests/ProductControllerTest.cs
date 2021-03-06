// <copyright file="ProductControllerTest.cs">Copyright ©  2016</copyright>
using System;
using System.Web.Mvc;
using KillerApp.Controllers;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KillerApp.Controllers.Tests
{
    /// <summary>This class contains parameterized unit tests for ProductController</summary>
    [PexClass(typeof(ProductController))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class ProductControllerTest
    {
        /// <summary>Test stub for Toevoegen(String, Int32)</summary>
        [PexMethod]
        public ActionResult ToevoegenTest(
            [PexAssumeUnderTest]ProductController target,
            string productNaam,
            int specificatieID
        )
        {
            ActionResult result = target.Toevoegen(productNaam, specificatieID);
            return result;
            // TODO: add assertions to method ProductControllerTest.ToevoegenTest(ProductController, String, Int32)
        }
    }
}
