using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HauntedIsland
{
    public class Inventory : MonoBehaviour
    {
        private Bone bone;

        private void OnTriggerEnter(Collider other) {
            Bone bone = other.GetComponent<Bone>();
            if(bone != null){
                CollectItem(bone);
            }
            CampFire campfire = other.GetComponent<CampFire>();
            if(campfire != null){
                DropItem(campfire);
            }
        }

        public void CollectItem(Bone bone){
            this.bone = bone;
            bone.transform.SetParent(transform);
            bone.gameObject.SetActive(false);
        }

        public void DropItem(CampFire campFire){
            campFire.BurnItem(bone);
        }
    }
}
