namespace Playground.Test
{
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

}
