using UnityEngine;
using UniRx;
using System;
using ViewModel;
using Commands;

namespace Components
{
    public class GemRaycastInput : MonoBehaviour
    {
        public GameFactoryCmd gameFactoryCmd;
        public GameData gameData;
        public GemAnimationDisplay gemAnimationDisplay;
        private GemData gemData;

        private Renderer _myRenderer;
        private Rigidbody _myRigidbody;
        private Vector3 _scaleDesired;
        private bool _isMaxScale = false;
        private float _scaleFactor = 0.01f;
        private Vector3 _scaleHandler;

        private IDisposable _observable; 

        public void StartGem(GemData gemData)
        {
            this.gemData = gemData;
            gemAnimationDisplay.StartGemAnimation(gemData);

            _myRigidbody = GetComponent<Rigidbody>();
            _myRenderer = GetComponent<Renderer>();

            _myRenderer.material = gemData.gemInactiveMaterial;
            _scaleDesired = transform.localScale;
            _scaleHandler = transform.localScale;
            _isMaxScale = false;

            _observable = Observable.Interval(TimeSpan.FromMilliseconds(gemData.smoothTimeFactor))
                .Subscribe(IntervalScale);

            _myRigidbody.drag = gemData.smoothDragGravity;
            transform.localScale = new Vector3(gemData._minScale, gemData._minScale, gemData._minScale);
            gameData.currentGemInScreen.Value++;
        }

        private void IntervalScale(long interval)
        {
            //Debug.Log($"localscale = {transform.localScale}, gemMaxScale = {gemData._maxScale}");

            if(transform.localScale.x >= gemData._maxScale)
                GemDestroy(true);

            if(_isMaxScale && transform.localScale.x <= gemData._maxScale)
            {
                transform.localScale += new Vector3(_scaleFactor,_scaleFactor,_scaleFactor);
            }
            
            if(!_isMaxScale && transform.localScale.x >= gemData._minScale)
                transform.localScale -= new Vector3(_scaleFactor,_scaleFactor,_scaleFactor);
        }

        void OnTriggerEnter(Collider collider)
        {
            if(collider.CompareTag("Ground"))
            {
                GemDestroy(false);
            }
        }

        public void OnPointerEnter()
        {
            SetMaterial(true);
            SetScale(true);
        }

        public void OnPointerExit()
        {
            SetMaterial(false);
            SetScale(false);
        }

        void SetMaterial(bool status)
        {
            if (gemData.gemActiveMaterial != null && gemData.gemInactiveMaterial != null)
            {
                _myRenderer.material = status ? gemData.gemActiveMaterial : gemData.gemInactiveMaterial;
            }
        }

        void SetScale(bool status)
        {
            if(status)
            {
                _isMaxScale = true;
                _scaleDesired = new Vector3(gemData._maxScale, gemData._maxScale, gemData._maxScale);
            } 
            else 
            {
                _isMaxScale = false;
                _scaleDesired = new Vector3(gemData._minScale, gemData._minScale, gemData._minScale);
            }
        }   

        void GemDestroy(bool destroyByUser)
        {
            // Destroy Gamobject
            this.gameObject.SetActive(false);
            Destroy(this.gameObject.transform.parent.gameObject, 0.1f);

            // Execute command
            Gem gem = new Gem();
            gem.gemData = gemData;
            gem.gemGameObject = this.gameObject;
            gem.destroyByUser = destroyByUser;

            gameFactoryCmd.GemaTurn(gem, gameData).Execute();
            
            // Destroy instance
            _observable.Dispose();
        }
    }    
}
