using System;
using System.Collections;
using BinaryEyes.Common.Attributes;
using BinaryEyes.Common.Extensions;
using QueueGame.Enums;
using QueueGame.Managers;
using UnityEngine;

namespace QueueGame.Components
{
    public class NonPlayer
        : MonoBehaviour
    {
        [SerializeField] [ReadOnlyField] private NonPlayerState _state;
        [SerializeField] private float _rotationTime;
        [SerializeField] private Transform _turnPivot;
        private Coroutine _facingProcess;
        public NonPlayerState State => _state;

        public void EngageWithPlayer()
        {
            if (_state == NonPlayerState.EngagedWithPlayer)
                throw new InvalidOperationException("non-player is already engaged");

            this.LogMessage("EngagingWithPlayer");
            _state = NonPlayerState.EngagedWithPlayer;
            _facingProcess = StartCoroutine(FacePlayer());
        }

        private IEnumerator FacePlayer()
        {
            var source = _turnPivot.position;
            var rotationDirection = source.x < 0.0f ? +1.0f : -1.0f;
            var targetRotation = rotationDirection*175.0f;
            var tween = LeanTween.rotateY(_turnPivot.gameObject, targetRotation, _rotationTime);
            yield return new WaitWhile(() => LeanTween.isTweening(tween.uniqueId));
        }
    }
}
