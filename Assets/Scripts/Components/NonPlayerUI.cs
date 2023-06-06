using System.Collections;
using BinaryEyes.Common.Extensions;
using TMPro;
using UnityEngine;

namespace QueueGame.Components
{
    public class NonPlayerUI
        : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private TextMeshProUGUI _textOutput;

        public void Deactivate()
        {
            _canvasGroup.gameObject.SetActive(false);
        }

        public Coroutine Show(float time)
        {
            this.LogMessage("Showing");
            UpdateCanvasPosition();

            _canvasGroup.gameObject.SetActive(true);
            return StartCoroutine(FadeGroup(1.0f, time));
        }

        public Coroutine Hide(float time)
        {
            this.LogMessage("Hiding");
            _canvasGroup.gameObject.SetActive(true);
            return StartCoroutine(FadeGroup(0.0f, time));
        }

        private IEnumerator FadeGroup(float alpha, float time)
        {
            var tween = LeanTween.alphaCanvas(_canvasGroup, alpha, time);
            yield return new WaitWhile(() => LeanTween.isTweening(tween.uniqueId));

            if (alpha < 0.1f)
                _canvasGroup.gameObject.SetActive(false);
        }

        private void UpdateCanvasPosition()
        {
            var position = transform.position;
            var scaleValue = position.x < 0.0f ? 1.0f : -1.0f;
            var canvasScale = new Vector3(-scaleValue, 1.0f, 1.0f);
            _canvasGroup.transform.localScale = Vector3.Scale(_canvasGroup.transform.localScale, canvasScale);

            var textScale = new Vector3(-scaleValue, 1.0f, 1.0f);
            _textOutput.transform.localScale = Vector3.Scale(_textOutput.transform.localScale, textScale);
        }
    }
}
