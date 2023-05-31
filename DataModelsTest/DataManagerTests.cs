using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataModels;
using System;
using System.Collections.Generic;
using System.Text;
using DataModels.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataModels.Tests
{
    [TestClass()]
    public class DataManagerTests
    {
        [TestMethod()]
        public void GetTest()
        {
            var data = DataManager.Get(DataProvidersList.SqlServer);

            Assert.IsFalse(false);
        }
    }
}