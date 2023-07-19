using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HauntedIsland.Player
{
    public interface IInteractable{
        public void Interact(PlayerController player);
    }
}
