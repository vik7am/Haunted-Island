using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HauntedIsland
{
    public interface IInteractable{
        public void Interact(Inventory inventory);
        public string getItemInfo();
    }
    public class Inventory : MonoBehaviour
    {
        private Bone bone;
        private Collider[] colliders;
        [SerializeField] private float interactionRange;
        [SerializeField] private LayerMask interactableLayer;
        private Transform camTransform;
        private IInteractable currentInteractable;

        private void Start() {
            camTransform = Camera.main.transform;
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
                string itemInfo = currentInteractable.getItemInfo();
                Debug.Log(" ItemInfo : " + itemInfo);
            }
            else
                currentInteractable = null;
        }

        public void CollectItem(Bone bone){
            this.bone = bone;
            bone.transform.SetParent(transform);
            bone.gameObject.SetActive(false);
        }

        public Bone DropItem(){
            return bone;
        }
    }
}
