using System.Linq;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Playground.Test
{
    [TestClass]
    public class MyTest
    {
        [TestMethod]
        public void WizardChooseGryffindor()
        {
            //arrange

            var wizard = new Wizard("harry potter");

            //act
            wizard.SelectHouse("Gryffindor");

            //assert
            Assert.AreEqual("Gryffindor", wizard.House);
        }
    }

    public class Wizard
    {
        private string name;

        public Wizard(string name)
        {
            this.name = name;
        }

        public string House { get; internal set; }

        internal void SelectHouse(string house)
        {
            this.House = house;
        }
    }
}
