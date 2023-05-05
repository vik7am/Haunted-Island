using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HauntedIsland
{
    public class CampFire : MonoBehaviour, IInteractable
    {
        // public void BurnItem(Bone bone){
        //     bone.BurnBone();
        // }

        public string GetItemName(){
            return "Campfire";
        }

        public string GetActionInfo(Inventory inventory){
            if(inventory.GetItem())
                return "Press E to Burn Bone";
            return "";
        }

        public void Interact(Inventory inventory){
            Bone bone = inventory.GetItem();
            inventory.DropItem();
            bone.BurnBone();
            Destroy(bone.gameObject);
        }
    }
}
