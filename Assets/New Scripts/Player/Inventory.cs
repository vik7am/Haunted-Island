using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HauntedIsland.Core;

namespace HauntedIsland.Player
{
    public class Inventory : MonoBehaviour
    {
        private ICollectable _collectable;

        private void Update() {
            if(Input.GetKeyDown(KeyCode.F) && _collectable != null){
                DropCollectable();
            }
        }

        public void AddCollectable(ICollectable collectable){
            _collectable = collectable;
            _collectable.Collect(transform);
        }

        public ICollectable GetCollectable(){
            ICollectable collectable = _collectable;
            _collectable = null;
            return collectable;
        }

        public void DropCollectable(){
            _collectable.Drop(transform.position + transform.forward);
            _collectable = null;
        }

        public bool HasCollectable => _collectable != null;

    }
}
