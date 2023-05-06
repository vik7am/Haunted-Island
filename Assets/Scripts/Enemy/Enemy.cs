using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HauntedIsland
{
    public class Enemy : MonoBehaviour, IDetector
    {
        public bool playerDetected {get; private set;}
        public Transform playerTransform {get; private set;}

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
