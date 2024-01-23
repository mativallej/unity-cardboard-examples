using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ViewModel;

namespace Commands
{
    [CreateAssetMenu(fileName = "GameCmdFactory", menuName = "Scriptable/Game Command Factory")]    
    public class GameFactoryCmd : ScriptableObject
    {
        public TurnGemDestroy GemaTurn(Gem gem, GameData gameData)
        {
            return new TurnGemDestroy(gem, gameData);
        }

        public TurnPlayCmd PlayTurn(GameData gameData)
        {
            return new TurnPlayCmd(gameData);
        }
    }
}
