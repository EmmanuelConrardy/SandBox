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
        [DataRow(House.Gryffindor)]
        [DataRow(House.Slytherin)]
        [DataRow(House.Hufflepuff)]
        [DataRow(House.Ravenclaw)]

        public void WizardChoose(House house)
        {
            //arrange
            var wizard = new Wizard("harry potter");

            //act
            wizard.SelectHouse(house);

            //assert
            Assert.AreEqual(house, wizard.House);
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
        Gryffindor,
        Slytherin,
        Hufflepuff,
        Ravenclaw
    }
}
