using BinaryEyes.Common.Attributes;
using BinaryEyes.Common.Extensions;
using UnityEngine;

namespace QueueGame.Components
{
    public class NonPlayerTapArea
        : MonoBehaviour
    {
        [SerializeField] [ReadOnlyField] private int _tapCount;
        [SerializeField] [ReadOnlyField] private float _tapTimeLeft;

        private void OnMouseDown()
        {
            this.LogMessage("MouseDown");
        }

        private void Update()
        {

        }
    }
}
