using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ViewModel;

namespace Commands
{
    public class TurnGemDestroy : ICommand
    {
        private Gem gem;
        private GameData gameData;

        public TurnGemDestroy(Gem gem, GameData gameData)
        {
            this.gem = gem;
            this.gameData = gameData;
        }

        public void Execute()
        {
            CounterUpdate(gem);
            gameData.OnDestroy.OnNext(gem);
            gem.gemData.OnDestroy.OnNext(gem);
            gameData.currentGemInScreen.Value--;
        }
        
        private void CounterUpdate(Gem gem)
        {
            if(gem.destroyByUser)
            {
                Debug.Log($"[TurnGemDestroy] Gem {gem.gemData.gemName} has been destroyed by the user.");
                if(gem.gemData.gemType == TypeGem.GOOD)
                {
                    gameData.currentPoints.Value += gem.gemData.gemPoint;
                } 
                else 
                {
                    gameData.currentPoints.Value -= gem.gemData.gemPoint;       
                }
            }
            else
            {
                Debug.Log($"[TurnGemDestroy] Gem {gem.gemData.gemName} has been destroyed by the ground.");
                if(gem.gemData.gemType == TypeGem.GOOD)
                {
                    gameData.currentPoints.Value -= gem.gemData.gemPoint;
                }
            }
        }
    }
}
