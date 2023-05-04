using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HauntedIsland
{
    public class Enemy : MonoBehaviour
    {
        public void kill(){
            Destroy(gameObject);
        }
        
    }
}
