using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HauntedIsland
{
    public class Bone : MonoBehaviour
    {
        [SerializeField] private Enemy enemy;
        
        public void BurnBone(){
            enemy.kill();
        }

        void Update()
        {
        
        }
    }
}
