using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HauntedIsland.Core;
using System;

namespace HauntedIsland.Player
{
    public class Collector : MonoBehaviour
    {
        private ICollectable collectable;
        private Inventory inventory;

        public event Action<ICollectable> onNearCollectable;

        private void Awake() {
            inventory = GetComponent<Inventory>();
        }

        private void Update() {
            if(Input.GetKeyDown(KeyCode.E) && collectable != null){
                inventory.AddCollectable(collectable);
            }
        }

        private void OnTriggerEnter(Collider other) {
            if(other.TryGetComponent<ICollectable>(out ICollectable collectable)){
                this.collectable = collectable;
                onNearCollectable?.Invoke(collectable);
            }
        }

        private void OnTriggerExit(Collider other) {
            if(other.TryGetComponent<ICollectable>(out ICollectable collectable)){
                this.collectable = null;
                onNearCollectable?.Invoke(null);
            }
        }
    }
}
