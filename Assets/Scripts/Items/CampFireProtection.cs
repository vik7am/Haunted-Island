using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HauntedIsland
{
    public class CampFireProtection : MonoBehaviour
    {
        PlayerInfoTransmitter transmitter;

        private void OnTriggerEnter(Collider other) {
            UpdateTransmissionState(other, false);
        }

        private void OnTriggerExit(Collider other) {
            UpdateTransmissionState(other, true);
        }

        public void UpdateTransmissionState(Collider other, bool state){
            transmitter = other.gameObject.GetComponent<PlayerInfoTransmitter>();
            if(transmitter != null)
                transmitter.SetTransmission(state);
        }
    }
}
