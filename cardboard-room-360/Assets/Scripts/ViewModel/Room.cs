using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace ViewModel
{
    [CreateAssetMenu(fileName = "new Room", menuName = "Scriptable/Room")]
    public class Room : ScriptableObject
    {
        public string roomName;
        public Material roomMaterial;
    }
}
