using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ViewModel;

namespace Commands
{
    public class TurnPlayCmd : ICommand
    {
        private GameData gameData;

        public TurnPlayCmd(GameData gameData)
        {
            this.gameData = gameData;
        }

        public void Execute()
        {
            Debug.Log($"[TurnPlayGame] Initialize new game with values minMaxScreen = ({gameData.gameMinGem},{gameData.gameMaxGem}) and spawnRate = {gameData.gameSpawnRate}.");
            gameData.currentGemInScreen.Value = 0;
            gameData.currentPoints.Value = 0;
        }
    }
}
