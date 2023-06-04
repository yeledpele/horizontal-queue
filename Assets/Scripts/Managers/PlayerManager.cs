using QueueGame.Components;
using UnityEngine;

namespace QueueGame.Managers
{
    public class PlayerManager
        : SingletonManager<PlayerManager>
    {
        [SerializeField] private Player _player;
        public Player CurrentPlayer => _player;
    }
}
