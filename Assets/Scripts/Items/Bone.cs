using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HauntedIsland
{
    public class Bone : MonoBehaviour, IInteractable
    {
        [SerializeField] private Enemy enemy;
        
        public void BurnBone(){
            enemy.kill();
        }

        public string getItemInfo()
        {
            return "Bone";
        }

        public void Interact(Inventory inventory)
        {
            Debug.Log("Bone Interaction");
            inventory.CollectItem(this);
        }
    }
}
