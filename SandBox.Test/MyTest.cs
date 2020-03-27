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

         [TestMethod]
        public void WizardUseStupefix()
        {
            //arrange
            var harry = new Wizard("Harry Potter");
            harry.Learn(new Spell("stupefix","stun",1));
            var albus = new Wizard("Albus Dumbledore");
            
            //act
            harry.Use("stupefix").On(albus);

            //assert
            Assert.AreEqual(9,albus.Health);
            Assert.AreEqual("stun",albus.State);
        }
    }

    internal class Spell
    {
        public string Name;
        private string state;
        private int damage;

        public Spell(string name, string state, int damage)
        {
            this.Name = name;
            this.state = state;
            this.damage = damage;
        }

        internal void On(Wizard wizard)
        {
            wizard.Health -= this.damage;
            wizard.State = this.state;
        }
    }

    public class Wizard
    {
        private string name;

        public Wizard(string name)
        {
            this.name = name;
            this.Health = 10;
        }

        public House House { get; internal set; }
        public int Health { get; internal set; }
        public string State { get; internal set; }

        private List<Spell> spells = new List<Spell>();
        internal void Learn(Spell spell)
        {
            spells.Add(spell);
        }

        internal void SelectHouse(House house)
        {
            this.House = house;
        }

        internal Spell Use(string spellName)
        {
            return spells.Find(s => s.Name == spellName);
        }
    }

    public enum House {
        Gryffindor,
        Slytherin,
        Hufflepuff,
        Ravenclaw
    }
}
