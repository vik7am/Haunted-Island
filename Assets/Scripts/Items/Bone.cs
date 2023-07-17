using UnityEngine;

namespace HauntedIsland
{
    public class Bone : MonoBehaviour, IInteractable
    {
        public Enemy enemy {get; private set;}
        private BoneManager boneManager;

        public void SetEnemy(Enemy enemy){
            this.enemy = enemy;
        }

        public void SetBoneManager(BoneManager boneManager){
            this.boneManager = boneManager;
        }
        
        public void BurnBone(){
            boneManager.RemoveBoneFromList(this);
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
