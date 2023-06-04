using BinaryEyes.Common.Extensions;
using QueueGame.Enums;
using UnityEngine;

namespace QueueGame.Data
{
    [CreateAssetMenu(menuName = "Queues/Name Dictionary")]
    public class NameDictionary
        : ScriptableObject
    {
        [SerializeField] private string[] _maleNames;
        [SerializeField] private string[] _femaleNames;

        public string GetRandomName(Gender gender)
        {
            var list = gender == Gender.Male ? _maleNames : _femaleNames;
            return list.GetRandom();
        }
    }
}
