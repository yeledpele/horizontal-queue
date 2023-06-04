using System.Collections;
using QueueGame.Components;
using QueueGame.Enums;
using UnityEngine;

namespace QueueGame.Managers
{
    public class PlayerManager
        : SingletonManager<PlayerManager>
    {
        [Header("State")]
        [SerializeField] private Player _player;
        public Player CurrentPlayer => _player;

        [Header("Input")]
        [SerializeField] private KeyCode LeanLeftKey = KeyCode.A;
        [SerializeField] private KeyCode LeanRightKey = KeyCode.D;
        [SerializeField] private KeyCode MoveForwardKey = KeyCode.W;

        public void Initialize()
        {
            Debug.Log("InitializingPlayerManager");
            enabled = true;
        }

        private void Update()
        {
            var action = Input.GetKey(LeanLeftKey) ? PlayerAction.LeanLeft
                : Input.GetKey(LeanRightKey) ? PlayerAction.LeanRight
                : PlayerAction.None;

            _player.SetAction(action);
        }

        protected override void Awake()
        {
            base.Awake();
            enabled = false;
        }
    }
}
