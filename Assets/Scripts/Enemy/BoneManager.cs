using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HauntedIsland.Old
{
    public class BoneManager : MonoBehaviour
    {
        [SerializeField] private List<Bone> boneList;
        private int currentBoneIndex;
        private int boneCount;

        public int BoneCount => boneCount;

        public static event System.Action onBoneDestroyed;

        private void Awake() {
            boneCount = boneList.Count;
            currentBoneIndex = 0;
        }

        private void Start() {
            
        }

        public Vector3 GetNextBonePosition(){
            Debug.Log(boneCount);
            currentBoneIndex = (currentBoneIndex + 1) % boneCount;
            return boneList[currentBoneIndex].transform.position;
        }

        public void RemoveBoneFromList(Bone bone){
            boneList.Remove(bone);
            onBoneDestroyed?.Invoke();
        }

    }
}
