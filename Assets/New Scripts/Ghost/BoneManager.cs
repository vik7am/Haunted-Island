using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HauntedIsland.Ghost
{
    public class BoneManager : MonoBehaviour
    {
        private List<Bone> boneList;
        private int currentBoneIndex;
        private int boneCount;

        public int BoneCount => boneCount;

        public static event System.Action onBoneDestroyed;

        private void Awake() {
            InitializeBoneList();
            currentBoneIndex = 0;
        }

        private void InitializeBoneList(){
            boneList = new List<Bone>();
            boneCount = transform.childCount;
            for(int i=0; i<boneCount; i++){
                if(transform.GetChild(i).TryGetComponent<Bone>(out Bone bone)){
                    boneList.Add(bone);
                }
            }
        }

        public Vector3 GetNextBonePosition(){
            currentBoneIndex = (currentBoneIndex + 1) % boneCount;
            return boneList[currentBoneIndex].transform.position;
        }

        public void RemoveBoneFromList(Bone bone){
            boneList.Remove(bone);
            onBoneDestroyed?.Invoke();
        }
    }
}
