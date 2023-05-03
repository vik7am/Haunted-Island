using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HauntedIsland
{
    public class CampFire : MonoBehaviour
    {
        PlayerInfoTransmitter transmitter;

        private void OnTriggerEnter(Collider other) {
            transmitter = other.gameObject.GetComponent<PlayerInfoTransmitter>();
            if(transmitter != null)
                transmitter.SetTransmission(false);
        }

        private void OnTriggerExit(Collider other) {
            transmitter = other.gameObject.GetComponent<PlayerInfoTransmitter>();
            if(transmitter != null)
                transmitter.SetTransmission(true);
        }
    }
}
