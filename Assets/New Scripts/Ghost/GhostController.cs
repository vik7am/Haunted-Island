using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HauntedIsland.Ghost
{
    public class GhostController : MonoBehaviour
    {
        [SerializeField] private BoneManager boneManager;

        public BoneManager BoneManager => boneManager;
    }
}
