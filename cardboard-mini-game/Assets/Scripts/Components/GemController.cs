using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ViewModel;
using UniRx;
using System;
using Random=UnityEngine.Random;

namespace Components
{
    public class GemController : MonoBehaviour
    {
        public GameData gameData;
        public GameObject gemContainer;
        public IDisposable delayObservable;

        void Start()
        {
            delayObservable = Observable.Interval(TimeSpan.FromSeconds(gameData.gameDelayInitialization))
                .Subscribe(StartDelay)
                .AddTo(this);
        }

        private void StartDelay(long obj)
        {
            Observable.Interval(TimeSpan.FromSeconds(gameData.gameSpawnRate))
                .Subscribe(IntervalController)
                .AddTo(this);
            
            delayObservable.Dispose();
        }

        private void IntervalController(long timer)
        {
            if(gameData.gameMaxGem == gameData.currentGemInScreen.Value)
                return;
            
            SpawnGemRandomly();
            Debug.Log("[GemController] Spawn new gem to the game.");
        }

        private void SpawnGemRandomly()
        {
            int i = Random.Range(0, gameData.gameGemPrefabs.Length);
            GameObject gem = Instantiate(gameData.gameGemPrefabs[i], gameData.gameGemPrefabs[i].transform.position, gameData.gameGemPrefabs[i].transform.rotation);
            gem.SetActive(false);
            
            int j = Random.Range(0, gameData.gameGemType.Length);
            gem.GetComponentInChildren<GemRaycastInput>().StartGem(gameData.gameGemType[j]);

            gem.transform.SetParent(gemContainer.transform);
            TeleportRandomly(gem);
            gem.SetActive(true);
        }

        public void TeleportRandomly(GameObject gem)
        {
            // Computes new object's location.
            float angle = Random.Range(-Mathf.PI, Mathf.PI);
            float distance = Random.Range(-2.5f, 2.5f);
            float height = Random.Range(6, 6.55f);
            Vector3 newPos = new Vector3(Mathf.Cos(angle) * distance, height,
                                        Mathf.Sin(angle) * distance);

            // Moves the parent to the new position (siblings relative distance from their parent is 0).
            gem.transform.localPosition = newPos;
        }
    }
}
