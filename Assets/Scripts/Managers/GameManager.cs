using System.Collections;
using UnityEngine;

namespace QueueGame.Managers
{
    public class GameManager
        : SingletonManager<GameManager>
    {
        private void Start() => StartCoroutine(InitializeGame());

        private IEnumerator InitializeGame()
        {
            yield return null;//wait one frame for other scripts awake/start.
            QueueGenerator.Instance.Initialize();

            yield return new WaitForSeconds(0.5f);
            yield return FadeManager.Instance.HidePanel();

            PlayerManager.Instance.Initialize();
        }
    }
}
