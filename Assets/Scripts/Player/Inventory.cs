using UnityEngine;
using HauntedIsland.Core;
using System;

namespace HauntedIsland.Player
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private Transform dropPosition;
        private ICollectable _collectable;

        public string CollectableName => _collectable.GetName();

        public static event Action<bool> onBonePickDrop;

        private void Update() {
            if(Input.GetKeyDown(KeyCode.F) && _collectable != null){
                DropCollectable();
            }
        }

        public void AddCollectable(ICollectable collectable){
            _collectable = collectable;
            _collectable.Collect(transform);
            onBonePickDrop?.Invoke(true);
        }

        public ICollectable GetCollectable(){
            ICollectable collectable = _collectable;
            _collectable = null;
            onBonePickDrop?.Invoke(false);
            return collectable;
        }

        public void DropCollectable(){
            _collectable.Drop(dropPosition.position);
            _collectable = null;
            onBonePickDrop?.Invoke(false);
        }

        public bool HasCollectable => _collectable != null;
    }
}
