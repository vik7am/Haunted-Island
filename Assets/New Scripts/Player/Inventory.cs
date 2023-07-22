using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HauntedIsland.Core;
using System;

namespace HauntedIsland.Player
{
    public class Inventory : MonoBehaviour
    {
        private ICollectable _collectable;

        public static event Action<bool> onHoldingBone;

        public string CollectableName => _collectable.GetName();

        private void Update() {
            if(Input.GetKeyDown(KeyCode.F) && _collectable != null){
                DropCollectable();
            }
        }

        public void AddCollectable(ICollectable collectable){
            _collectable = collectable;
            _collectable.Collect(transform);
            onHoldingBone?.Invoke(true);
        }

        public ICollectable GetCollectable(){
            ICollectable collectable = _collectable;
            _collectable = null;
            onHoldingBone?.Invoke(false);
            return collectable;
        }

        public void DropCollectable(){
            _collectable.Drop(transform.position + transform.forward);
            _collectable = null;
            onHoldingBone?.Invoke(false);
        }

        public bool HasCollectable => _collectable != null;

    }
}
