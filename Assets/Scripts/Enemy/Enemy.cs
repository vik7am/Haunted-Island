using System;
using UnityEngine;

namespace HauntedIsland.Old
{
    public class Enemy : MonoBehaviour, IDetector
    {
        private bool playerDetected;
        private Transform playerTransform;
        [SerializeField] private BoneManager boneManager;
        
        public bool PlayerDetected => playerDetected;
        public Transform PlayerTransform => playerTransform;
        public BoneManager BoneManager => boneManager;

        private void OnEnable() {
            BoneManager.onBoneDestroyed += OnBoneDestroyed;
        }

        private void OnBoneDestroyed(){
            if(boneManager.BoneCount == 0){
                Debug.Log("Enemy Destroyed");
            }
        }

        public void Detect(Transform other){
            playerDetected = true;
            playerTransform = other;
        }

        public void kill(){
            Destroy(gameObject);
        }

        public void PlayerOutOfRange(){
            playerDetected = false;
            playerTransform = null;
        }
        
    }
}
