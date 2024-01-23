using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using ViewModel;
using System;
using TMPro;

namespace Components
{
    public class RoomNameDisplay : MonoBehaviour
    {
        public TextMeshProUGUI nameLabel;
        public RoomData roomData;

        void Start()
        {
            roomData.currentRoomName
                .Subscribe(DisplayName)
                .AddTo(this);
        }

        private void DisplayName(string name)
        {
            nameLabel.text = name;
        }
    }
}
