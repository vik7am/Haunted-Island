using System;
using HauntedIsland.Ghost;
using HauntedIsland.Player;
using UnityEngine;

namespace HauntedIsland
{
    public class LightManager : MonoBehaviour
    {
        private bool isPlayerNearGhost;
        private bool isPlayerHoldingBone;
        private Light _light;

        public static event Action<bool> onDayNightChange;
        
        private void Awake() {
            _light = GetComponent<Light>();
        }

        private void OnEnable() {
            Inventory.onBonePickDrop += PlayerHoldingBone;
            GhostController.onPlayerDetected += PlayerNearGhost;
        }

        private void OnDisable() {
            Inventory.onBonePickDrop -= PlayerHoldingBone;
            GhostController.onPlayerDetected -= PlayerNearGhost;
        }

        private void PlayerNearGhost(bool value){
            isPlayerNearGhost = value;
            UpdateLighting();
        }

        private void PlayerHoldingBone(bool isHoldingBone){
            isPlayerHoldingBone = isHoldingBone;
            UpdateLighting();
        }

        private void UpdateLighting(){
            if(isPlayerNearGhost || isPlayerHoldingBone){
                _light.enabled = false;
                onDayNightChange?.Invoke(false);
            }
            else{
                _light.enabled = true;
                onDayNightChange?.Invoke(true);
            }
        }
    }
}
