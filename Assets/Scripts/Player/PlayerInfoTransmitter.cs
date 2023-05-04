using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HauntedIsland
{
    public class PlayerInfoTransmitter : MonoBehaviour
    {
        [SerializeField] LayerMask enemyLayer;
        [SerializeField] private float transmittionRadius;
        private PlayerMovement playerMovement;
        private Collider[] colliders;
        public bool transmitterActive;
        

        private void Awake() {
            transmitterActive = true;
            playerMovement = GetComponent<PlayerMovement>();
        }

        public void SetTransmission(bool status){
            transmitterActive = status;
        }

        private void FixedUpdate() {
            if(playerMovement.IsIdle() || !transmitterActive)
                return;
            TransmitInfo();
        }

        public void TransmitInfo(){
            colliders = Physics.OverlapSphere(transform.position, transmittionRadius, enemyLayer, QueryTriggerInteraction.Collide);
            foreach(Collider collider in colliders){
                IDetector detector =  collider.transform.GetComponent<IDetector>();
                if(detector != null){
                    detector.Detect(transform);
                }
            }
        }
    }
}
