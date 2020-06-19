using System.Linq;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Playground.Test
{
    [TestClass]
    public class WizardTest
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
        public void InitAuror()
        {
            //Arrange
            var auror = new Auror("Claf");

            //Assert
            Assert.AreEqual(2,auror.Ability);
            Assert.AreEqual(2,auror.Power);
            Assert.IsTrue(auror.GetSpells().Any(s => s.Name=="heal"));
        }

        [TestMethod]
        public void InitDeathEater()
        {
            //Arrange
            var auror = new DeathEater("Cassoulet");

            //Assert
            Assert.AreEqual(2,auror.Ability);
            Assert.AreEqual(2,auror.Power);
            Assert.IsTrue(auror.GetSpells().Any(s => s.Name=="confuse"));
        }

        [TestMethod]
        public void BuildCampDeathEater()
        {
            //arrange
            var campDeathEaterGenerator = new CampGenerator();

            //Act
            var camp = campDeathEaterGenerator.Build(10,WizardType.DeathEater);

            //Assert
            Assert.AreEqual(10,camp.Count);
            Assert.IsTrue(camp.All(c => c.GetType()==typeof(DeathEater)));
        }

        [TestMethod]
        public void BuildCampAuror()
        {
            //arrange
            var campAurorGenerator = new CampGenerator();

            //Act
            var camp = campAurorGenerator.Build(10,WizardType.Auror);

            //Assert
            Assert.AreEqual(10,camp.Count);
            Assert.IsTrue(camp.All(c => c.GetType()==typeof(Auror)));
        }
    }

    public enum WizardType
    {
        Auror,
        DeathEater
    }

    public class CampGenerator
    {
        public List<Wizard> Build(int number, WizardType type)
        {

            var camp = new List<Wizard>();
            for (int i = 0; i < number; i++)
            {
                if(type == WizardType.Auror)
                    camp.Add(new Auror($"{i}"));
                else
                    camp.Add(new DeathEater($"{i}"));
            }
            return camp;
        }
    }
}
