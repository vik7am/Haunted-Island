using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HauntedIsland
{
    public class CampFire : MonoBehaviour
    {
        public void BurnItem(Bone bone)
        {
            bone.BurnBone();
        }
    }
}
