using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HauntedIsland
{
    public interface IDetector{
        public void Detect(Transform other);
    }
}
