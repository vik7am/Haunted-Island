using UnityEngine;

namespace HauntedIsland.Old
{
    public class GenericMonoSingleton<T> : MonoBehaviour where T : GenericMonoSingleton<T>
    {
        private static T instance;
        public static T Instance { get{return instance;} }

        protected void Awake() {
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
