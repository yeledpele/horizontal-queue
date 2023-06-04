using BinaryEyes.Common.Attributes;
using BinaryEyes.Common.Extensions;
using QueueGame.Enums;
using UnityEngine;

namespace QueueGame.Components
{
    public class NonPlayer
        : MonoBehaviour
    {
        [SerializeField] [ReadOnlyField] private NonPlayerState _state;
        [SerializeField] private Transform _turnPivot;
        public NonPlayerState State => _state;

        public void EngageWithPlayer()
        {
            this.LogMessage("EngagingWithPlayer");
            _state = NonPlayerState.EngagedWithPlayer;
        }
    }
}
