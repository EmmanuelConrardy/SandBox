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
            Assert.AreEqual(3,game.EvaluateWinningHit, "Evaluate has not been hit");
            Assert.AreEqual(2,game.TurnHit, "Turn has not been hit");
            Assert.IsNotNull(game.ResultHasBeenDisplay);
        }
    }
    public class GameStub : Game
    {
        public int WinningConditionHitTurn {get; set;}
        public bool ResultHasBeenDisplay;
        public bool HasBeenInitialize { get; internal set; }
        public int TurnHit { get; internal set; }
        public int EvaluateWinningHit { get; internal set; }

        protected override void Turn()
        {
            TurnHit++;
        }

        protected override bool GameContinue()
        {
            EvaluateWinningHit++;
            return WinningConditionHitTurn > EvaluateWinningHit;
        }

        protected override void Init()
        {
            HasBeenInitialize = true;
        }

        protected override void DisplayResult()
        {
            ResultHasBeenDisplay = true;
        }
    }

    public abstract class Game
    {
        public void Start()
        {
            Init();

            LoopTurn();

            DisplayResult();
        }

        protected abstract void DisplayResult();
        protected virtual void LoopTurn(){
            while(GameContinue())
            {
                Turn();
            }
        }
        protected abstract void Turn();
        protected abstract bool GameContinue();
        protected abstract void Init();
    }
}