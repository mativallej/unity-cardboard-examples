using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ViewModel;
using UniRx;

namespace Components
{
    public class GemAnimationDisplay : MonoBehaviour
    {
        public Transform gemTransform;
        private GemData gemData;

        public void StartGemAnimation(GemData gemData)
        {
            this.gemData = gemData;

            gemData.OnDestroy
                .Subscribe(DisplayAnimation)
                .AddTo(this);
        }

        private void DisplayAnimation(Gem gem)
        {
            if(gem.gemGameObject == this.gameObject)
                Explode(gem.gemData.gemMotionGo);
        }

        void Explode(GameObject motionFx)
        {
            GameObject explosion = Instantiate(motionFx, gemTransform.position, gemTransform.rotation);
            Destroy(explosion, 3f);
        }
    }
}
