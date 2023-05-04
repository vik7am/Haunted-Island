using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HauntedIsland
{
    public class PreyDetector : MonoBehaviour, IDetector
    {
        public Transform playerTransform {get; private set;}
        public bool playerDetected {get; private set;}

        public void Detect(Transform info)
        {
            playerDetected = true;
            playerTransform = info;
        }

        public void PlayerEscaped(){
            playerDetected = false;
            playerTransform = null;
        }

        void Update()
        {
        
        }
    }
}
