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
            wizard.SelectHouse(House.Gryffindor);

            //assert
            Assert.AreEqual(House.Gryffindor, wizard.House);
        }
    }

    public class Wizard
    {
        private string name;

        public Wizard(string name)
        {
            this.name = name;
        }

        public House House { get; internal set; }

        internal void SelectHouse(House house)
        {
            this.House = house;
        }
    }

    public enum House {
        Gryffindor
    }
}
