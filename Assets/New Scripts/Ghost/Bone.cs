using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HauntedIsland.Core;
using System;

namespace HauntedIsland.Ghost
{
    public class Bone : MonoBehaviour, ICollectable
    {
        private BoneManager boneManager;
        private BoxCollider boxCollider;
        private Rigidbody _rigidbody;

        public event Action<Bone> onBoneDestroyed;

        private void Awake(){
            boneManager = transform.parent.GetComponent<BoneManager>();
            boxCollider = GetComponent<BoxCollider>();
            _rigidbody = GetComponent<Rigidbody>();
        }

        public string GetItemName(){
            return "Bone";
        }

        public void Collect(Transform playerTransform){
            Debug.Log("collect called");
            transform.SetParent(playerTransform);
            transform.localPosition = Vector3.zero;
            boxCollider.enabled = false;
            _rigidbody.useGravity = false;
            transform.GetChild(0).gameObject.SetActive(false);
            Debug.Log("bone collected");
        }

        public void Drop(Vector3 dropPosition){
            transform.SetParent(boneManager.transform);
            transform.position = dropPosition;
            boxCollider.enabled = true;
            _rigidbody.useGravity = true;
            transform.GetChild(0).gameObject.SetActive(true);
            Debug.Log("bone dropped");
        }

        public void Destroy(){
            onBoneDestroyed?.Invoke(this);
            Destroy(gameObject);
        }

        // public string GetActionInfo(Inventory inventory){
        //     return "Press E to Take";
        // }

        // public void Interact(Inventory inventory){
        //     inventory.CollectItem(this);
        // }
    }
}
