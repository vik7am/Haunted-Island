using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HauntedIsland.Player
{
    public class PlayerController : MonoBehaviour
    {
        private Inventory inventory;
        public Inventory Inventory => inventory;

        private void Awake() {
            inventory = GetComponent<Inventory>();
        }
    }
}
