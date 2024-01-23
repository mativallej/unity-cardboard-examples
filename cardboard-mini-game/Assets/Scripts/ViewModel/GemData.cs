using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace ViewModel
{
    [CreateAssetMenu(fileName = "GemData", menuName = "Scriptable/Gem Data")]    
    public class GemData : ScriptableObject
    {
        [Header("Gem Data")]
        public string gemName;
        public TypeGem gemType;
        public int gemPoint;
        public Material gemActiveMaterial;
        public Material gemInactiveMaterial;
        public string gemMotionName;
        public GameObject gemMotionGo;
        
        [Header("Game Parameters")]
        [Range(0,100)] public float smoothTimeFactor;
        [Range(0,45)] public float smoothDragGravity;

        [Header("Gem Scale")]
        public float _minScale;
        public float _maxScale = 1.5f;

        public ISubject<Gem> OnDestroy = new Subject<Gem>();
    }

    public enum TypeGem
    {
        GOOD,
        BAD
    }
}
