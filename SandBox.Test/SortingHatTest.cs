
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Playground.Test
{
    [TestClass]
    public class SortingHatTest
    {
        [TestMethod]
        public void SortingHatAssign()
        {
            //arrange
           var sortingHat = SortingHat.GetInstance();
           var sortingHatEvil = SortingHat.GetInstance();

            //assert
            Assert.AreEqual(sortingHat,sortingHatEvil);
        }
    
    }
}
