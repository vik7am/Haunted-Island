using System.Collections.Generic;
using UnityEngine;

namespace HauntedIsland
{
    public interface IInteractable{
        public void Interact(Inventory inventory);
        public string GetItemName();
        public string GetActionInfo(Inventory inventory);
    }
    public class Inventory : MonoBehaviour
    {
        public List<Bone> boneList {get; private set;}
        private Collider[] colliders;
        [SerializeField] private float interactionRange;
        [SerializeField] private LayerMask interactableLayer;
        private Transform camTransform;
        private IInteractable currentInteractable;

        private void Start() {
            camTransform = Camera.main.transform;
            boneList = new List<Bone>();
        }

        private void Update() {
            if(Input.GetKeyDown(KeyCode.E) && currentInteractable != null){
                currentInteractable.Interact(this);
            }
        }

        private void FixedUpdate() {
            CastRay();
        }

        private void CastRay(){
            RaycastHit hitInfo;
            if(Physics.Raycast(camTransform.position, camTransform.forward, out hitInfo, interactionRange, interactableLayer, QueryTriggerInteraction.Collide)){
                IInteractable item = hitInfo.transform.GetComponent<IInteractable>();
                if(currentInteractable != null && currentInteractable == item)
                    return;
                currentInteractable = item;
                UpdateHUDUI();
                UIManager.Instance.ShowUI(UIType.HUD_MENU);
            }
            else{
                currentInteractable = null;
                UIManager.Instance.CloseActiveUI();
            }
        }

        private void UpdateHUDUI(){
            string itemName = currentInteractable.GetItemName();
            string itemInfo = currentInteractable.GetActionInfo(this);
            UIManager.Instance.SetHUDData(itemName, itemInfo);
        }

        public void CollectItem(Bone bone){
            boneList.Add(bone);
            bone.transform.SetParent(transform);
            bone.gameObject.SetActive(false);
        }

        public List<Bone> GetItems(){
            return boneList;
        }

        public void DropItems(){
            boneList.Clear();
            UpdateHUDUI();
        }
    }
}
