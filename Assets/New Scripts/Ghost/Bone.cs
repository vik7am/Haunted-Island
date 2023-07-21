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
            sphereCollider.enabled = false;
            _rigidbody.useGravity = false;
            transform.GetChild(0).gameObject.SetActive(false);
        }

        public void Drop(Vector3 dropPosition){
            transform.SetParent(boneManager.transform);
            transform.position = dropPosition;
            sphereCollider.enabled = true;
            _rigidbody.useGravity = true;
            transform.GetChild(0).gameObject.SetActive(true);
        }

        public void Destroy(){
            onBoneDestroyed?.Invoke(this);
            Destroy(gameObject);
        }

        public string GetName(){
            return "Bone";
        }

        public string InteractionMessage(){
            return "Press E to Pickup " + GetName();
        }
    }
}
