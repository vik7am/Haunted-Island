using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HauntedIsland
{
    public class Bone : MonoBehaviour, IInteractable
    {
        public Enemy enemy {get; private set;}

        public void SetEnemy(Enemy enemy){
            this.enemy = enemy;
        }
        
        public void BurnBone(){
            enemy.kill();
            GameManager.Instance.EnemyKilled();
        }

        public string GetItemName(){
            return "Bone";
        }

        public string GetActionInfo(Inventory inventory){
            return "Press E to Take";
        }

        public void Interact(Inventory inventory){
            inventory.CollectItem(this);
        }
    }
}
