using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace ViewModel
{
    [CreateAssetMenu(fileName = "GameData", menuName = "Scriptable/Game Data")]    
    public class GameData : ScriptableObject
    {
        public int gameMinGem;
        public int gameMaxGem;
        public float gameSpawnRate;
        [Range(0,10)] public int gameDelayInitialization;
        public GameObject[] gameGemPrefabs;
        public GemData[] gameGemType;
            
        public IntReactiveProperty currentPoints = new IntReactiveProperty();
        public IntReactiveProperty currentGemInScreen = new IntReactiveProperty();
        public ISubject<Gem> OnDestroy = new Subject<Gem>();
    }
}
