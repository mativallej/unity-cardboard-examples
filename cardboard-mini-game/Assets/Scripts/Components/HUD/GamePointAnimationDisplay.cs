using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ViewModel;
using UniRx;
using TMPro;

namespace Components
{
    public class GamePointAnimationDisplay : MonoBehaviour
    {
        public Animator animator;
        public TextMeshProUGUI pointerLabel;
        public GameData gameData;

        void Start()
        {
            gameData.OnDestroy
                .Subscribe(DisplayAnimationNewPoint)
                .AddTo(this);
        }

        private void DisplayAnimationNewPoint(Gem gem)
        {
            if(gem.destroyByUser)
            {
                if(gem.gemData.gemType == TypeGem.GOOD)
                {
                    pointerLabel.text = $"+{Mathf.Abs(gem.gemData.gemPoint)}";
                } 
                else 
                {
                    pointerLabel.text = $"-{Mathf.Abs(gem.gemData.gemPoint)}";
                }
                
                animator.SetTrigger("Pointer");
            }
            else
            {
                if(gem.gemData.gemType == TypeGem.GOOD)
                {
                    pointerLabel.text = $"-{Mathf.Abs(gem.gemData.gemPoint)}";
                    animator.SetTrigger("Pointer");
                }
            }
        }
    }
}
