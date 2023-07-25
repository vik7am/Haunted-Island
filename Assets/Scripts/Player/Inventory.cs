using UnityEngine;
using HauntedIsland.Core;
using System;

namespace HauntedIsland.Player
{
    public class Inventory : MonoBehaviour
    {
        private ICollectable _collectable;
        [SerializeField] private Transform dropPosition;

        public string CollectableName => _collectable.GetName();

        public static event Action<bool> onHoldingBone;

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
            _collectable.Drop(dropPosition.position);
            _collectable = null;
            onHoldingBone?.Invoke(false);
        }

        public bool HasCollectable => _collectable != null;
    }
}
