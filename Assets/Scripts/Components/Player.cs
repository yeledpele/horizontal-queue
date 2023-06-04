using QueueGame.Enums;
using UnityEngine;

namespace QueueGame.Components
{
    public class Player
        : MonoBehaviour
    {
        [Header("State")]
        [SerializeField] private PlayerState _state;

        [Header("Nodes")]
        [SerializeField] private Transform _leanPivot;
        [SerializeField] private Transform _movePivot;
        [SerializeField] private Transform _cameraBone;
        [SerializeField] private Camera _camera;

        [Header("Lean")]
        [SerializeField] private float _leanRotationMax;
        [SerializeField] private float _leanOffsetMax;

        [Header("Lean (Debug)")]
        [SerializeField] private float _leanRotationTarget;
        [SerializeField] private float _leanOffsetTarget;
        
        public PlayerState State => _state;


        private void Awake()
            => _state = PlayerState.Standing;

        public void SetAction(PlayerAction action)
        {
            var leanDirection = action == PlayerAction.LeanLeft ? -1.0f : action == PlayerAction.LeanRight ? +1.0f : 0.0f;
            _leanRotationTarget = leanDirection*_leanRotationMax;
            _leanOffsetTarget = leanDirection*_leanOffsetMax;
        }

        private void Update()
        {
            UpdateLeanRotation();
            UpdateLeanOffset();
            _camera.transform.position = _cameraBone.position;
            _leanRotationTarget = 0.0f;
            _leanOffsetTarget = 0.0f;
        }

        private void UpdateLeanRotation()
        {
            var leanNodeRotation = _leanPivot.eulerAngles;
            leanNodeRotation.x = Mathf.LerpAngle(leanNodeRotation.x, _leanRotationTarget, Time.deltaTime*5.0f);
            _leanPivot.eulerAngles = leanNodeRotation;
        }

        private void UpdateLeanOffset()
        {
            var moveNodePosition = _movePivot.position;
            moveNodePosition.x = Mathf.Lerp(moveNodePosition.x, _leanOffsetTarget, Time.deltaTime*5.0f);
            _movePivot.position = moveNodePosition;
        }
    }
}
