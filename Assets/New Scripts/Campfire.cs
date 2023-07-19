using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HauntedIsland.Interactable;
using HauntedIsland.Player;
using HauntedIsland.Core;

namespace HauntedIsland.Interactable
{
    public class Campfire : MonoBehaviour, IInteractable
    {
        public void Interact(PlayerController player)
        {
            Inventory inventory = player.Inventory;
            if(!inventory.HasCollectable) return;
            ICollectable collectable = inventory.GetCollectable();
            collectable.Destroy();
            Debug.Log("collectable Destroyed");
        }
    }
}
