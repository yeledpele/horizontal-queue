using System;
using System.Collections;
using BinaryEyes.Common.Attributes;
using BinaryEyes.Common.Extensions;
using QueueGame.Enums;
using UnityEngine;

namespace QueueGame.Components
{
    public class NonPlayer
        : MonoBehaviour
    {
        [Header("State")]
        [SerializeField] [ReadOnlyField] private NonPlayerState _state;
        [SerializeField] [ReadOnlyField] private float _currentAttentionSpan;

        [Header("Rotation")]
        [SerializeField] private float _rotationTime;
        [SerializeField] private Transform _turnPivot;

        [Header("Attention")]
        [SerializeField] private float _attentionSpan;
        [SerializeField] private float _attentionSpanDepletionRate;
        private Coroutine _currentProcess;
        public NonPlayerState State => _state;
        public float CurrentAttentionSpan => _currentAttentionSpan;

        public void EngageWithPlayer()
        {
            if (_state != NonPlayerState.Waiting)
                throw new InvalidOperationException($"failed to engage with player: npcState={State}");

            _state = NonPlayerState.Turning;
            _currentProcess = StartCoroutine(FacePlayer());
        }

        private IEnumerator FacePlayer()
        {
            this.LogMessage("FacingPlayer");
            var source = _turnPivot.position;
            var rotationDirection = source.x < 0.0f ? +1.0f : -1.0f;
            var targetRotation = rotationDirection*175.0f;
            var tween = LeanTween.rotateY(_turnPivot.gameObject, targetRotation, _rotationTime);
            yield return new WaitWhile(() => LeanTween.isTweening(tween.uniqueId));

            this.LogMessage("EngagedWithPlayer");
            _state = NonPlayerState.EngagedWithPlayer;
            _currentProcess = StartCoroutine(LoseInterestInPlayer());
        }

        private IEnumerator LoseInterestInPlayer()
        {
            _currentAttentionSpan = _attentionSpan;
            while (_currentAttentionSpan > 0.0f)
            {
                yield return null;
                _currentAttentionSpan -= _attentionSpanDepletionRate*Time.deltaTime;
            }

            this.LogMessage("LostInterestInPlayer");
            _state = NonPlayerState.Turning;
            var source = _turnPivot.position;
            var rotationDirection = source.x < 0.0f ? -1.0f : +1.0f;
            var targetRotation = rotationDirection*1.0f;
            var tween = LeanTween.rotateY(_turnPivot.gameObject, targetRotation, _rotationTime);
            yield return new WaitWhile(() => LeanTween.isTweening(tween.uniqueId));

            this.LogMessage("WaitingInLine");
            _state = NonPlayerState.Waiting;
        }
    }
}
