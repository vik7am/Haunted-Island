using System;
using System.Collections;
using System.Collections.Generic;
using HauntedIsland.Player;
using UnityEngine;

namespace HauntedIsland
{
    public class LightManager : MonoBehaviour
    {
        public static event Action<bool> onEnableDarkMode;
        private bool isPlayerNearGhost;
        private bool isPlayerHoldingBone;
        private Light _light;
        
        private void Awake() {
            _light = GetComponent<Light>();
        }

        private void OnEnable() {
            Inventory.onHoldingBone += PlayerHoldingBone;
            PlayerController.onNearGhost += PlayerNearGhost;
        }

        private void OnDisable() {
            Inventory.onHoldingBone -= PlayerHoldingBone;
            PlayerController.onNearGhost -= PlayerNearGhost;
        }

        private void PlayerNearGhost(bool value){
            isPlayerNearGhost = value;
            UpdateLighting();
        }

        private void PlayerHoldingBone(bool value){
            isPlayerHoldingBone = value;
            UpdateLighting();
        }

        private void UpdateLighting(){
            if(isPlayerNearGhost || isPlayerHoldingBone){
                _light.enabled = false;
                onEnableDarkMode?.Invoke(true);
            }
            else{
                _light.enabled = true;
                onEnableDarkMode?.Invoke(false);
            }
        }

    }
}
