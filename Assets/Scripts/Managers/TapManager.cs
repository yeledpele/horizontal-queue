using UnityEngine;

namespace QueueGame.Managers
{
    public class TapManager
        : SingletonManager<TapManager>
    {
        public void Initialize()
        {
            Debug.Log("InitializingTapManager");

        }
    }
}
