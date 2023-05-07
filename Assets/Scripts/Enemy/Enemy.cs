using UnityEngine;

namespace HauntedIsland
{
    public class Enemy : MonoBehaviour, IDetector
    {
        private bool playerDetected;
        private Transform playerTransform;
        
        public bool PlayerDetected {get => playerDetected;}
        public Transform PlayerTransform {get => playerTransform;}

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
