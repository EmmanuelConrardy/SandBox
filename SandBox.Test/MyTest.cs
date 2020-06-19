using System.Linq;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Playground.Test
{
    [TestClass]
    public class MyTest
    {
        [TestMethod]
        [DataRow(House.Gryffindor, "Harry Potter")]
        [DataRow(House.Slytherin, "Drago")]
        [DataRow(House.Hufflepuff, "Cédric Digory")]
        [DataRow(House.Ravenclaw, "Luna Lovegood")]

        public void SortingHatAssign(House house, string wizardName)
        {
            //arrange
            var wizard = new Wizard(wizardName);

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

}
