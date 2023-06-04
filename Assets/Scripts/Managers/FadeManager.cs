using System.Collections;
using BinaryEyes.Common;
using UnityEngine;

namespace QueueGame.Managers
{
    public class FadeManager
        : SingletonManager<FadeManager>
    {
        [SerializeField] private CanvasGroup _fadeGroup;
        public Coroutine ShowPanel() => Fade(1.0f);
        public Coroutine HidePanel() => Fade(0.0f);

        private Coroutine Fade(float target)
        {
            _fadeGroup.blocksRaycasts = true;
            _fadeGroup.gameObject.SetActive(true);
            return StartCoroutine(PerformFade(target));
        }

        private IEnumerator PerformFade(float target)
        {
            var tween = LeanTween.alphaCanvas(_fadeGroup, target, 0.75f).setEaseInCubic();
            yield return new WaitWhile(() => LeanTween.isTweening(tween.uniqueId));

            _fadeGroup.blocksRaycasts = false;
            _fadeGroup.gameObject.SetActive(target > 0.1f);
        }

        protected override void Awake()
        {
            base.Awake();
            _fadeGroup.gameObject.SetActive(true);
            _fadeGroup.alpha = 1.0f;
            _fadeGroup.blocksRaycasts = true;
        }
    }
}
