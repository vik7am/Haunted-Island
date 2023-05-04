using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HauntedIsland
{
    public class CampFire : MonoBehaviour, IInteractable
    {
        Bone bone;

        public void BurnItem(Bone bone)
        {
            bone.BurnBone();
        }

        public string getItemInfo()
        {
            return "Campfire";
        }

        public void Interact(Inventory inventory)
        {
            Debug.Log("Campfire interaction");
            bone = inventory.DropItem();
            bone.BurnBone();
        }
    }
}
