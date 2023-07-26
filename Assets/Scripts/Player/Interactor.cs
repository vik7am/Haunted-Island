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
        public static event Action<Inventory, IInteractable> onInteractableEnter;
        public static event Action onInteractableExit;

        private void Awake() {
            player = GetComponent<PlayerController>();
            inventory = GetComponent<Inventory>();
        }

        private void Update() {
            if(Input.GetKeyDown(KeyCode.E) && interactable != null){
                interactable.Interact(player);
                if(interactable.IsInteractable())
                    onInteractableEnter?.Invoke(inventory, interactable);
                else
                    onInteractableExit?.Invoke();
            }
        }

        private void OnTriggerEnter(Collider other) {
            if(other.TryGetComponent<IInteractable>(out IInteractable interactable)){
                this.interactable = interactable;
                onInteractableEnter?.Invoke(inventory, interactable);
            }
        }

        private void OnTriggerExit(Collider other) {
            if(other.TryGetComponent<IInteractable>(out IInteractable interactable)){
                this.interactable = null;
                onInteractableExit?.Invoke();
            }
        }
    }
}
