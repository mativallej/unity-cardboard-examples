using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using ViewModel;
using System;

namespace Components
{
    public class RoomDisplay : MonoBehaviour
    {
        public Renderer rendererRoom;
        public RoomData roomData;

        void Start()
        {
            roomData.currentRoomMaterial
                .Subscribe(DisplayRoom)
                .AddTo(this);
        }

        private void DisplayRoom(Material roomMaterial)
        {
            Debug.Log($"Updating material room to {roomMaterial.name}");
            rendererRoom.material = roomMaterial;
        }
    }
}
