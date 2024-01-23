using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ViewModel;

namespace Components
{
    public class RoomChangeInput : MonoBehaviour
    {
        [Header("Data")]
        public GameCommandFactory gameCmdFactory;
        public RoomData roomData;
        
        [Header("Rooms")]
        public Room[] rooms;
        
        void Start()
        {
            UpdateRandomRoom();
        }

        public void OnClick()
        {
            UpdateRandomRoom();
        }

        private void UpdateRandomRoom()
        {
            int i = Random.Range(0, rooms.Length - 1);
            gameCmdFactory.PerfomRoom(roomData, rooms[i]).Execute();
        }
    }
}
