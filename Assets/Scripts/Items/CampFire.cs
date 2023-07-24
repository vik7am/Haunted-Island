using UnityEngine;
using HauntedIsland.Player;
using HauntedIsland.Core;

namespace HauntedIsland.Interactable
{
    public class Campfire : MonoBehaviour, IInteractable
    {
        public string GetName(){
            return "Campfire";
        }

        public void Interact(PlayerController player){
            Inventory inventory = player.Inventory;
            if(!inventory.HasCollectable) return;
            ICollectable collectable = inventory.GetCollectable();
            collectable.Destroy();
        }

        public string InteractionMessage(Inventory inventory){
            if(inventory.HasCollectable){
                return "Press E to burn " + inventory.CollectableName;
            }
            return "";
        }

        public bool IsInteractable(){
            return true;
        }
    }
}
