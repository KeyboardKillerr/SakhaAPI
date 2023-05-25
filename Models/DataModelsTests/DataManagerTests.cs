using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.Tests
{
    [TestClass()]
    public class DataManagerTests
    {
        [TestMethod()]
        public void GetTest()
        {
            var data = DataManager.Get(DataProvider.Sqlite);
            Assert.IsFalse(false);
        }
    }
}