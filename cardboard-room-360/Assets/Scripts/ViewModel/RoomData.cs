using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace ViewModel
{
    [CreateAssetMenu(fileName = "RoomData", menuName = "Scriptable/Room Data")]
    public class RoomData : ScriptableObject
    {
        public StringReactiveProperty currentRoomName = new StringReactiveProperty();
        public ReactiveProperty<Material> currentRoomMaterial = new ReactiveProperty<Material>();
        public Material[] roomsMaterial;
    }
}
