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
            harry.Learn(Spell.ValueOf("stupefix","stun",1));
            var albus = new Wizard("Albus Dumbledore");
            
            //act
            harry.Use("stupefix").On(albus);

            //assert
            Assert.AreEqual(9,albus.Health);
            Assert.AreEqual("stun",albus.State);
        }

        [TestMethod]
        public void SpellWithSameDamageAndStateAreEqual(){
            //arrange
            var spell = Spell.ValueOf("stupefix","stun",1);
            var spell2 = Spell.ValueOf("stupefix-alternatif","stun",1);

            //act
            var result = spell.Equals(spell2);

            //assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void SpellWithSameDamageAndStateReturnSameHashCode(){
            //arrange
            var spell = Spell.ValueOf("stupefix","stun",1);
            var spell2 = Spell.ValueOf("stupefix-alternatif","stun",1);

            //act
            var result = spell.GetHashCode() == spell2.GetHashCode();

            //assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void SpellIsInstanciedInValueOfMethod(){
            var spell = Spell.ValueOf("stupefix","stun",1);

            Assert.AreEqual(typeof(Spell),spell.GetType());
        
        }
    }

    public sealed class Spell
    {
        public readonly string Name;
        private string state;
        private int damage;

        private Spell(string name, string state, int damage)
        {
            this.Name = name;
            this.state = state;
            this.damage = damage;
        }

        public static Spell ValueOf(string name, string state, int damage)
        {
           return new Spell(name,state,damage);
        }

        public override bool Equals(object? s){
            var spell = s as Spell;
            if(spell == null){
                return false;
            }

            var isStateEqual = this.state.Equals(spell.state);
            var isDamageEqual = this.damage.Equals(spell.damage);
            return isDamageEqual && isStateEqual;
        }

        public override int GetHashCode(){
            return this.damage.GetHashCode() + this.state.GetHashCode();
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
