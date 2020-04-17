using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SandBox.Test
{
    [TestClass]
    public class GameTest
    {
        //Initialisation
        //Turn
            //Dual
            //EvaluateWinning
        //DisplayResult
         [TestMethod]
        public void GameWinningAfter3turnDisplayResult()
        {

            var game = new GameStub();
            game.WinningConditionHitTurn = 3;

            game.Start();
            
            Assert.IsNotNull(game.HasBeenInitialize);
            Assert.AreEqual(3,game.DualHit);
            Assert.AreEqual(3,game.EvaluateWinningHit);
            Assert.IsNotNull(game.ResultHasBeenDisplay);
        }
    }
    public class GameStub : Game
    {
        public int WinningConditionHitTurn {get; set;}
        public bool ResultHasBeenDisplay;
        public bool HasBeenInitialize { get; internal set; }
        public int DualHit { get; internal set; }
        public int EvaluateWinningHit { get; internal set; }

        //ovverride la méthode d'execution des tour pour / virtual
    }
    public abstract class Game
    {
        public void Start()
        {
            //initialisation

            //executiondestour(evaluation)
            //..

            //DiplayRésult
        }
    }
}