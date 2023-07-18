using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HauntedIsland.Ghost
{
    public class Bone : MonoBehaviour
    {
        private BoneManager boneManager;

        public void SetBoneManager(BoneManager boneManager){
            this.boneManager = boneManager;
        }
        
        public void BurnBone(){
            boneManager.RemoveBoneFromList(this);
        }

        public string GetItemName(){
            return "Bone";
        }

        // public string GetActionInfo(Inventory inventory){
        //     return "Press E to Take";
        // }

        // public void Interact(Inventory inventory){
        //     inventory.CollectItem(this);
        // }
    }
}
