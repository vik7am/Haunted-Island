using UnityEngine;

namespace HauntedIsland
{
    public class Enemy : MonoBehaviour, IDetector
    {
        private bool playerDetected;
        private Transform playerTransform;
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private Light enemylight;
        
        public bool PlayerDetected {get => playerDetected;}
        public Transform PlayerTransform {get => playerTransform;}

        public void Detect(Transform other){
            if(playerDetected)
                return;
            playerDetected = true;
            playerTransform = other;
            enemylight.enabled = true;
        }

        public void kill(){
            Destroy(gameObject);
        }

        public void KillPlayer(){
            audioSource.Stop();
            GameManager.Instance.GameOver();
        }

        public void PlayerOutOfRange(){
            playerDetected = false;
            playerTransform = null;
            enemylight.enabled = false;
        }
        
    }
}
