using BinaryEyes.Common.Attributes;
using QueueGame.Enums;
using UnityEngine;

namespace QueueGame.Components
{
    public class NonPlayerTapArea
        : MonoBehaviour
    {
        [SerializeField] [ReadOnlyField] private int _tapCount;
        [SerializeField] [ReadOnlyField] private float _tapTimeLeft;
        private NonPlayer _owner;

        private void OnMouseDown()
        {
            if (_owner.State != NonPlayerState.Waiting)
                return;

            _tapCount += 1;
            _tapTimeLeft = 0.5f;
            if (_tapCount < 2)
                return;

            _owner.EngageWithPlayer();
        }

        private void Update()
        {
            if (_tapCount == 0)
                return;

            _tapTimeLeft -= Time.deltaTime;
            if (_tapTimeLeft > 0.0f)
                return;
             
            _tapCount -= 1;
            if (_tapCount > 0)
                _tapTimeLeft = 0.5f;
        }

        private void Awake()
        {
            _owner = GetComponentInParent<NonPlayer>();
        }
    }
}
