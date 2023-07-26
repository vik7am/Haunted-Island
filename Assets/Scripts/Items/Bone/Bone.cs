using UnityEngine;
using HauntedIsland.Core;
using System;
using HauntedIsland.Interactable;
using HauntedIsland.Player;

namespace HauntedIsland.Ghost
{
    public class Bone : MonoBehaviour, IInteractable, ICollectable
    {
        private BoneManager boneManager;
        private SphereCollider sphereCollider;
        private Rigidbody _rigidbody;

        public event Action<Bone> onBoneDestroyed;

        private void Awake(){
            boneManager = transform.parent.GetComponent<BoneManager>();
            sphereCollider = GetComponent<SphereCollider>();
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void Collect(Transform playerTransform){
            transform.SetParent(playerTransform);
            transform.localPosition = Vector3.zero;
            ToggleBoneAttributes(false);
        }

        public void Drop(Vector3 dropPosition){
            transform.SetParent(boneManager.transform);
            transform.position = dropPosition;
            ToggleBoneAttributes(true);
        }

        private void ToggleBoneAttributes(bool status){
            sphereCollider.enabled = status;
            _rigidbody.useGravity = status;
            transform.GetChild(0).gameObject.SetActive(status);
        }

        public void Destroy(){
            onBoneDestroyed?.Invoke(this);
            Destroy(gameObject);
        }

        public string GetName(){
            return "Bone";
        }

        public string InteractionMessage(Inventory inventory){
            return "Press E to Pickup " + GetName();
        }

        public void Interact(PlayerController player){
            Inventory inventory = player.Inventory;
            inventory .AddCollectable(this);
        }

        public bool IsInteractable(){
            return sphereCollider.enabled == true;;
        }
    }
}
