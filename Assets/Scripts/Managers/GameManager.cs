using System.Collections;

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
        }
    }
}
