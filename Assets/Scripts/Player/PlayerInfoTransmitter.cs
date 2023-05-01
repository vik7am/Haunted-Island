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
        private RaycastHit[] hits;
        

        private void Awake() {
            playerMovement = GetComponent<PlayerMovement>();
        }

        private void FixedUpdate() {
            if(playerMovement.IsIdle())
                return;
            TransmitInfo();
        }

        public void TransmitInfo(){
            hits = Physics.SphereCastAll(transform.position, transmittionRadius, Vector3.forward, 0f, enemyLayer, QueryTriggerInteraction.UseGlobal);
            foreach(RaycastHit hit in hits){
                IDetector detector =  hit.transform.GetComponent<IDetector>();
                if(detector != null){
                    detector.Detect(transform);
                }
            }
        }
    }
}
