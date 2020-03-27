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
        [DataRow(House.Gryffindor, "harry potter")]
        [DataRow(House.Slytherin, "Drago")]
        [DataRow(House.Hufflepuff, "Cédric Digory")]
        [DataRow(House.Ravenclaw, "Luna Lovegood")]

        public void SortingHatAssign(House house, string wizardName)
        {
            //arrange
            var wizard = new Wizard(wizardName);
            var sortingHat = new SortingHat();

            //act
            sortingHat.TellTheHouseFor(wizard);

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

        [TestMethod]
        public void SortingHatAssignSlytherin(){
            //Arrange
            var sortingHat = new SortingHat();
            var drago = new Wizard("Drago");

            //Act
            sortingHat.TellTheHouseFor(drago);

            //Assert
            Assert.AreEqual(House.Slytherin, drago.House);

        }
    }

    public class SortingHat : ISortingHat //Service
    {
        public void TellTheHouseFor(Wizard wizard)
        {
            if(wizard.name == "Drago"){
                wizard.House = House.Slytherin;
            }else if(wizard.name == "harry potter"){
                wizard.House = House.Gryffindor;
            }else if(wizard.name == "Cédric Digory"){
                wizard.House = House.Hufflepuff;
            }else if(wizard.name == "Luna Lovegood"){
                wizard.House = House.Ravenclaw;
            }else {
                throw new Exception("error");
            }
           
        }
    }

    public interface ISortingHat
    {
        public void TellTheHouseFor(Wizard wizard);
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
        public readonly string name; // ID

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
