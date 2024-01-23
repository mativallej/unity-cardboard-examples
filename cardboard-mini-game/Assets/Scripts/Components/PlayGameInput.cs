using System;
using System.Collections;
using System.Collections.Generic;
using Commands;
using UnityEngine;
using ViewModel;

namespace Components
{
    public class PlayGameInput : MonoBehaviour
    {
        public GameFactoryCmd gameFactoryCmd;
        public GameData gameData;
        
        void Start()
        {
            PlayGame();
        }

        private protected void PlayGame()
        {
            gameFactoryCmd.PlayTurn(gameData).Execute();
        }
    }
}
