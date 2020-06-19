using System;

namespace Playground.Test
{
    public enum House {
        Gryffindor,
        Slytherin,
        Hufflepuff,
        Ravenclaw
    }
    public class SortingHat : ISortingHat //Service
    {
        private static SortingHat _instance;

        public void TellTheHouseFor(Wizard wizard)
        {
           if(wizard.name == "Harry Potter") {
             wizard.House = House.Gryffindor;
           } else if(wizard.name == "Cédric Digory") {
             wizard.House = House.Hufflepuff;
           } else if(wizard.name == "Luna Lovegood") {
             wizard.House = House.Ravenclaw;
           } else {
             wizard.House = House.Slytherin;
           }
        }

        public static SortingHat GetInstance()
        {
           if(_instance==null){
               _instance = new SortingHat();
           }

           return _instance;
        }
    }

    public interface ISortingHat
    {
         void TellTheHouseFor(Wizard wizard);
    }
}