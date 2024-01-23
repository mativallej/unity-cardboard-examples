using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using ViewModel;
using TMPro;
using System;

namespace Components
{    
    public class GamePointDisplay : MonoBehaviour
    {
        public GameData gameData;
        public TextMeshProUGUI pointLabel;

        void Start()
        {
            gameData.currentPoints
                .Subscribe(UpdatePointLabel)
                .AddTo(this);
        }

        private void UpdatePointLabel(int points)
        {
            pointLabel.gameObject.SetActive(false);
            pointLabel.gameObject.SetActive(true);
            
            pointLabel.text = points.ToString();
        }
    }
}
