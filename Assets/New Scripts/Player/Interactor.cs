using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using HauntedIsland.Interactable;

namespace HauntedIsland.Player
{
    public class Interactor : MonoBehaviour
    {
        private IInteractable interactable;
        private Inventory inventory;
        private PlayerController player;

        public Inventory Inventory => inventory;

        public event Action<IInteractable> onNearInteractable;

        private void Awake() {
            player = GetComponent<PlayerController>();
            inventory = GetComponent<Inventory>();
        }

        private void Update() {
            if(Input.GetKeyDown(KeyCode.E) && interactable != null){
                interactable.Interact(player);
            }
        }

        private void OnTriggerEnter(Collider other) {
            if(other.TryGetComponent<IInteractable>(out IInteractable interactable)){
                this.interactable = interactable;
                onNearInteractable?.Invoke(interactable);
                Debug.Log("entered interactable range");
            }
        }

        private void OnTriggerExit(Collider other) {
            if(other.TryGetComponent<IInteractable>(out IInteractable interactable)){
                this.interactable = null;
                onNearInteractable?.Invoke(null);
                Debug.Log("left interactable range");
            }
        }
    }
}
