using Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AnimePickTest
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void TestTitleByid()
        {
            Assert.IsNotNull(DataManager.TitleById(1));
        }

        [TestMethod]
        public void TestChangesTitleListBlockOnSame()
        {
            var list = DataManager.UlById(1);
            var firstVal = list.listType;

            DataManager.ChangeTitleListType(DataManager.TitleById(list.idTitle), list.listType);
            Assert.AreEqual(firstVal, list.listType);
        }
    }
}
