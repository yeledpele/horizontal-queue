using System.Collections;
using BinaryEyes.Common;
using BinaryEyes.Common.Extensions;
using UnityEngine;

namespace QueueGame.Managers
{
    public class TapManager
        : SingletonManager<TapManager>
    {
        public void Initialize()
        {
            this.LogInitializing();
            StartCoroutine(WaitForTap());
        }

        private IEnumerator WaitForTap()
        {
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        }
    }
}
