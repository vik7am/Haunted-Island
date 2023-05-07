using UnityEngine;

namespace HauntedIsland
{
    public class CampFire : MonoBehaviour, IInteractable
    {
        public string GetItemName(){
            return "Campfire";
        }

        public string GetActionInfo(Inventory inventory){
            if(inventory.GetItems().Count > 0)
                return "Press E to Burn Bones";
            return "";
        }

        public void Interact(Inventory inventory){
            foreach(Bone bone in inventory.boneList){
                bone.BurnBone();
                Destroy(bone.gameObject);
            }
            inventory.DropItems();
        }
    }
}
