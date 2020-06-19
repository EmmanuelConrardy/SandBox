using System.Linq;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Playground.Test
{
    [TestClass]
    public class SpellTest
    {
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
