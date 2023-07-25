using UnityEngine;
using TMPro;
using HauntedIsland.Player;
using HauntedIsland.Interactable;

namespace HauntedIsland.UI
{
    public class HeadsUpDisplayUI : MonoBehaviour
    {
        [SerializeField] private GameObject interactionPanel;
        [SerializeField] private TextMeshProUGUI interactableNameUI;
        [SerializeField] private TextMeshProUGUI interactableActionUI;
        
        private void OnEnable() {
            Interactor.onInteractableEnter += DisplayInfoPanel;
            Interactor.onInteractableExit += HideInfoPanel;
        }

        private void OnDisable() {
            Interactor.onInteractableEnter -= DisplayInfoPanel;
            Interactor.onInteractableExit -= HideInfoPanel;
        }

        private void DisplayInfoPanel(Inventory inventory, IInteractable interactable){
            interactionPanel.SetActive(true);
            interactableNameUI.text = interactable.GetName();
            interactableActionUI.text = interactable.InteractionMessage(inventory);
        }

        private void HideInfoPanel(){
            interactionPanel.SetActive(false);
        }
    }
}
