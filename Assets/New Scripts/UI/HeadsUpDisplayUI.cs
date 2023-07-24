using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HauntedIsland.Player;
using HauntedIsland.Interactable;
using TMPro;
using HauntedIsland.Core;

namespace HauntedIsland.UI
{
    public class HeadsUpDisplayUI : MonoBehaviour
    {
        [SerializeField] private GameObject interactionPanel;
        [SerializeField] private TextMeshProUGUI interactableNameUI;
        [SerializeField] private TextMeshProUGUI interactableActionUI;
        
        private void OnEnable() {
            Interactor.onNearInteractable += DisplayInfo;
        }

        private void OnDisable() {
            Interactor.onNearInteractable -= DisplayInfo;
        }

        private void DisplayInfo(Inventory inventory, IInteractable interactable){
            if(interactable == null){
                interactionPanel.SetActive(false);
                return;
            }
            interactionPanel.SetActive(true);
            interactableNameUI.text = interactable.GetName();
            interactableActionUI.text = interactable.InteractionMessage(inventory);
        }
    }
}
