using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HauntedIsland
{
    public class SpawnManager : GenericMonoSingleton<SpawnManager>
    {
        public Player playerPrefab;
        public Enemy enemyPrefab;
        public Bone bonePrefab;
        public Vector3 playerSpawnPos;
        public Vector3[] enemiesSpawnPos;
        public Vector3[] bonesSpawnPos;
        private Player player;
        private List<Enemy> enemyList;
        private List<Bone> boneList;

        private void Start() {
            enemyList = new List<Enemy>();
            boneList = new List<Bone>();
        }

        public void Spawn() {
            SpawnPlayer();
            SpawnEnemy();
        }

        public void SpawnPlayer(){
            player = Instantiate<Player>(playerPrefab, playerSpawnPos, Quaternion.identity);
        }

        public void SpawnEnemy(){
            for(int i=0; i<enemiesSpawnPos.Length; i++){
                enemyList.Add(Instantiate<Enemy>(enemyPrefab, enemiesSpawnPos[i], Quaternion.identity));
                boneList.Add(Instantiate<Bone>(bonePrefab, bonesSpawnPos[i], Quaternion.identity));
                boneList[i].SetEnemy(enemyList[i]);
            }
        }

        internal Transform GetPlayerTransForm()
        {
            return player.transform;
        }
    }
}
