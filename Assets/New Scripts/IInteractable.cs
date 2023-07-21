using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HauntedIsland.Player;

namespace HauntedIsland.Interactable
{
    public interface IInteractable{
        public void Interact(PlayerController player);
        public string GetName();
        public string InteractionMessage(Inventory inventory);
    }
}
