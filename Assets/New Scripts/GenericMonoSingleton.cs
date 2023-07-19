using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HauntedIsland
{
    public class GenericMonoSingleton<T> : MonoBehaviour where T: GenericMonoSingleton<T>
    {
        private static T instance;

        public static T Instance => instance;

        protected virtual void Awake(){
            if(instance == null){
                instance = (T)this;
                DontDestroyOnLoad(this);
            }
            else{
                Destroy(this);
            }
        }
    }
}
