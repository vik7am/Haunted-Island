using System;
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
        public event Action onAllBonesDestroyed;

        private void Awake() {
            InitializeBoneList();
            currentBoneIndex = boneCount-1;
        }

        private void InitializeBoneList(){
            boneList = new List<Bone>();
            boneCount = transform.childCount;
            for(int i=0; i<boneCount; i++){
                if(transform.GetChild(i).TryGetComponent<Bone>(out Bone bone)){
                    boneList.Add(bone);
                    bone.onBoneDestroyed += RemoveBoneFromList;
                }
            }
        }

        public Bone GetNextBone(){
            if(boneCount == 0)
                return null;
            currentBoneIndex = (currentBoneIndex + 1) % boneCount;
            return boneList[currentBoneIndex];
        }

        public void RemoveBoneFromList(Bone bone){
            boneCount--;
            boneList.Remove(bone);
            if(boneCount == 0){
                onAllBonesDestroyed?.Invoke();
            }
        }
    }
}
