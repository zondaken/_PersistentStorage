using UnityEngine;

namespace PersistentStorage.Manager
{
    public class SingletonPersistent<T> : Singleton<T> where T : MonoBehaviour
    {
        protected override void Awake()
        {
            base.Awake();
            
            DontDestroyOnLoad(transform.gameObject);
        }
    }
}