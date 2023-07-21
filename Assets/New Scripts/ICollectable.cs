using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HauntedIsland.Core
{
    public interface ICollectable{
        public void Collect(Transform playerTransform);
        public void Drop(Vector3 dropPosition);
        public string GetName();
        public string InteractionMessage();
        public void Destroy();
    }
}
