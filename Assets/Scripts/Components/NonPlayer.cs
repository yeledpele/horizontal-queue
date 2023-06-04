using QueueGame.Enums;
using UnityEngine;

namespace QueueGame.Components
{
    public class NonPlayer
        : MonoBehaviour
    {
        [SerializeField] private NonPlayerState _state;
        public NonPlayerState State => _state;
    }
}
