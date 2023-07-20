using System;
using System.Collections;
using System.Collections.Generic;
using HauntedIsland.Ghost;
using HauntedIsland.Player;
using UnityEngine;

namespace HauntedIsland.UI
{
    public enum UIPanelID{HEADS_UP_DISPLAY, GAME_WON, GAME_OVER}

    [System.Serializable]
    public class UIPanels{
        public UIPanelID id;
        public GameObject panel;
    }

    public class UIManager : MonoBehaviour
    {
        [SerializeField] private List<UIPanels> uiPanelList;
        private Dictionary<UIPanelID, GameObject> uiPanelDictionary;
        private GameObject activeUIPanel;

        private void Awake() {
            AddUIPanelsToDictionary();
        }

        private void OnEnable() {
            GhostController.onGhostKilled += SwitchToGameWonUI;
            PlayerController.onPlayerKilled += SwitchToGameOverUI;
        }

        private void OnDisable() {
            GhostController.onGhostKilled -= SwitchToGameWonUI;
            PlayerController.onPlayerKilled -= SwitchToGameOverUI;
        }

        private void SwitchToGameWonUI(){
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SwitchUI(UIPanelID.GAME_WON);
        }

        private void SwitchToGameOverUI(){
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SwitchUI(UIPanelID.GAME_OVER);
        }

        private void Start() {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            SwitchUI(UIPanelID.HEADS_UP_DISPLAY);
        }

        private void AddUIPanelsToDictionary(){
            uiPanelDictionary = new Dictionary<UIPanelID, GameObject>();
            foreach(UIPanels uiPanel in uiPanelList){
                uiPanelDictionary.Add(uiPanel.id, uiPanel.panel);
            }
        }

        public void SwitchUI(UIPanelID id){
            if(activeUIPanel){
                activeUIPanel.SetActive(false);
            }
            if(!uiPanelDictionary.ContainsKey(id)) return;
            activeUIPanel = uiPanelDictionary[id];
            activeUIPanel.SetActive(true);
        }
    }
}
