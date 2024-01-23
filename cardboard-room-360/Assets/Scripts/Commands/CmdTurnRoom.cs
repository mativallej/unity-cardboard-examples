using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ViewModel;

namespace Commands
{
    public class CmdTurnRoom : MonoBehaviour, ICommand
    {
        private RoomData roomData;
        private Room room;

        public CmdTurnRoom(RoomData roomData, Room room)
        {
            this.roomData = roomData;
            this.room = room;
        }

        public void Execute()
        {
            Debug.Log($"Updating current room to {room.roomName}");
            
            roomData.currentRoomName.Value = room.roomName;
            roomData.currentRoomMaterial.Value = room.roomMaterial;
        }
    }
}
