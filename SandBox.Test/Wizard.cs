using System.Collections.Generic;

namespace Playground.Test
{
    public class Wizard
    {
        public readonly string name; // ID
        public int Ability = 2;
         public int Power { get; internal set; } = 2;
        public Wizard(string name)
        {
            this.name = name;
            this.Health = 10;
            SortingHat.GetInstance().TellTheHouseFor(this);
        }

        public House House { get; internal set; }
        public int Health { get; internal set; }
        public string State { get; internal set; }

        private List<Spell> spells = new List<Spell>();
        public List<Spell> GetSpells()
        {
            return spells;
        }
        internal void Learn(Spell spell)
        {
            spells.Add(spell);
        }

        internal Spell Use(string spellName)
        {
            return spells.Find(s => s.Name == spellName);
        }
    }

    
    public class DeathEater : Wizard
    {
        public DeathEater(string name): base(name)
        {
            Learn(Spell.ValueOf("confuse",null,1));
        }
    }

    public class Auror : Wizard
    {
        public Auror(string name) : base(name)
        {
            Learn(Spell.ValueOf("heal",null,-1));
        }
    }

}
