using UnityEngine;

namespace QueueGame.Components
{
    public class Player
        : MonoBehaviour
    {
        [Header("State")]
        [SerializeField] private PlayerState _state;
        [SerializeField] private Transform _bodyPivot;
        [SerializeField] private Transform _neckPivot;
        [SerializeField] private Camera _camera;
        public PlayerState State => _state;

        private void Awake()
            => _state = PlayerState.Standing;

        public void SetAction(PlayerAction action)
        {

        }
    }

    public enum PlayerAction
    {
        None,
        LeanLeft,
        LeanRight,
    }

    public enum PlayerState
    {
        Standing,
        LeaningLeft,
        LeaningRight,
        StraighteningOut,
    }
}
