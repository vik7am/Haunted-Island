using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HauntedIsland.UI
{
    public enum UIPanelID{HEADS_UP_DISPLAY, GAME_WON, GAME_OVER}

    [System.Serializable]
    public struct UIPanels{
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

        private void Start() {
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
