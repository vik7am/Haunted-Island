using HauntedIsland.Player;

namespace HauntedIsland.Interactable
{
    public interface IInteractable{
        public void Interact(PlayerController player);
        public bool IsInteractable();
        public string GetName();
        public string InteractionMessage(Inventory inventory);
    }
}
