using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace COR
{
    [TestClass]
    public class smoothie
    {
        [TestMethod]
        public void Melissa_Like_Raspberry()
        {
            var smoothie = SmoothieFactory.Get("Raspberry");

            var smoothieLover = new ChainOfSmothieLovers()
                .Of("Daniel")
                .Then("Jane")
                .Then("Melissa") //Melissa like Raspberry
                .GetHead();

            bool hasBeenChoosen = smoothieLover.Recieve(smoothie);

            Assert.IsTrue(hasBeenChoosen);
        }

        [TestMethod]
        public void No_one_like_Pers()
        {
            var smoothie = SmoothieFactory.Get("Pears");

            var smothieLover = new ChainOfSmothieLovers()
                .Of("Daniel") //nope
                .Then("Jane") //nope
                .Then("Melissa") //nope
                .GetHead();

            bool hasBeenChoosen = smothieLover.Recieve(smoothie);

            Assert.IsFalse(hasBeenChoosen);
        }

        [TestMethod]
        public void Melissa()
        {
            var smothieLover = new ChainOfSmothieLovers()
                .Of("Daniel") //nope
                .Then("Jane") //nope
                .Then("Melissa") //nope
                .GetHead();

            SmoothieLover Melissa = smothieLover.GetByName("Melissa");

            Assert.AreEqual("Melissa", Melissa.GetName());
        }

        [TestMethod]
        public void Anonyme()
        {
            var smothieLover = new ChainOfSmothieLovers()
                .Of("Daniel") //nope
                .Then("Jane") //nope
                .Then("Melissa") //nope
                .GetHead();

            SmoothieLover anonyme = smothieLover.GetByName("Claf");

            Assert.AreEqual("", anonyme.GetName());
        }

        [TestMethod]
        public void TurnOff()
        {
            var smoothie = SmoothieFactory.Get("Raspberry");

            var smothieLover = new ChainOfSmothieLovers()
                .Of("Daniel") //nope
                .Then("Jane") //nope
                .Then("Melissa") //yes
                .GetHead();

            smothieLover.TurnOff("Melissa"); //but nope

            var result = smothieLover.Recieve(smoothie);

            Assert.IsFalse(result);
        }
    }

    internal class ChainOfSmothieLovers
    {
        private SmothieLoversFactory smoothieLovers;
        private SmoothieLover Head;
        private SmoothieLover Tail;

        public ChainOfSmothieLovers()
        {
            smoothieLovers = new SmothieLoversFactory();
        }
        internal ChainOfSmothieLovers Of(string name)
        {
            Head = smoothieLovers.Get(name);
            Tail = Head;
            return this;
        }

        internal ChainOfSmothieLovers Then(string name)
        {
            Tail.SetNextSmothieLover(smoothieLovers.Get(name));
            Tail = smoothieLovers.Get(name);
            return this;
        }

        public SmoothieLover GetHead()
        {
            return Head;
        }
    }

    public abstract class SmoothieLover
    {
        protected SmoothieLover NextSmothieLover;
        protected bool isOn = true;
        protected virtual string Name { get; }
        public string GetName()
        {
            return Name;
        }
        public void SetNextSmothieLover(SmoothieLover next)
        {
            this.NextSmothieLover = next;
        }

        protected abstract bool Check(Smoothie smoothie);
        protected abstract bool Excute(Smoothie smoothie);
        public virtual bool Recieve(Smoothie smoothie)
        {
            if (isOn && Check(smoothie))
                return Excute(smoothie);

            if (NextSmothieLover != null)
                return NextSmothieLover.Recieve(smoothie);

            return false;
        }

        public SmoothieLover GetByName(string name)
        {
            if (Name == name)
            {
                return this;
            }

            if (NextSmothieLover != null)
                return NextSmothieLover.GetByName(name);

            return new SmoothieLoverAnonyme();
        }

        internal void TurnOff(string name)
        {
            if (Name == name)
                isOn = false;

            if (NextSmothieLover != null)
                NextSmothieLover.TurnOff(name);
        }

        //définir de nouveau comportement

    }
    public class SmoothieLoverAnonyme : SmoothieLover
    {
        protected override string Name
        {
            get
            {
                return "";
            }
        }
        protected override bool Check(Smoothie smoothie)
        {
            return false;
        }

        protected override bool Excute(Smoothie smoothie)
        {
            return false;
        }
    }

    public class Melissa : SmoothieLover
    {
        protected override string Name
        {
            get
            {
                return "Melissa";
            }
        }
        protected override bool Check(Smoothie smoothie)
        {
            return smoothie.Name == "Raspberry";
        }

        protected override bool Excute(Smoothie smoothie)
        {
            Console.WriteLine($"I'm Melissa and this smoothie is mine : {smoothie.Name}");
            return true;
        }
    }

    public class Jane : SmoothieLover
    {
        protected override string Name
        {
            get
            {
                return "Jane";
            }
        }

        protected override bool Check(Smoothie smoothie)
        {
            return smoothie.Name == "Lemon";
        }

        protected override bool Excute(Smoothie smoothie)
        {
            Console.WriteLine($"I'm Jane and this smoothie is mine : {smoothie.Name}");
            return true;
        }
    }

    public class Daniel : SmoothieLover
    {
        protected override string Name
        {
            get
            {
                return "Jane";
            }
        }

        protected override bool Check(Smoothie smoothie)
        {
            return smoothie.Name == "Apple";
        }

        protected override bool Excute(Smoothie smoothie)
        {
            Console.WriteLine($"I'm Daniel and this smoothie is mine : {smoothie.Name}");
            return true;
        }
    }

    internal class SmothieLoversFactory
    {
        Dictionary<string, SmoothieLover> dict = new Dictionary<string, SmoothieLover>();
        public SmothieLoversFactory()
        {
            dict.Add("Melissa", new Melissa());
            dict.Add("Jane", new Jane());
            dict.Add("Daniel", new Daniel());
            dict.Add("Anonyme", new SmoothieLoverAnonyme());
        }
        internal SmoothieLover Get(string name)
        {
            return dict[name];
        }
    }

    internal class SmoothieFactory
    {
        internal static Smoothie Get(string name)
        {
            return new Smoothie(name);
        }
    }

    public class Smoothie
    {
        public Smoothie(string name)
        {
            Name = name;
        }

        public string Name { get; internal set; }
    }
}
