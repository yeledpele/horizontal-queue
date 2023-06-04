using System.Collections.Generic;
using QueueGame.Enums;
using UnityEngine;

namespace QueueGame.Components
{
    public class Character
        : MonoBehaviour
    {
        [SerializeField] private Gender _gender;
        public Gender Gender => _gender;

        [Header("Male")]
        [SerializeField] private GameObject[] _maleHair;
        [SerializeField] private GameObject[] _maleBeards;
        [SerializeField] private GameObject[] _maleShoes;

        [Header("Female")]
        [SerializeField] private GameObject[] _femaleHair;
        [SerializeField] private GameObject[] _femaleShoes;

        [Header("Accessories")]
        [SerializeField] private GameObject[] _scarves;
        [SerializeField] private GameObject[] _chains;
        [SerializeField] private GameObject[] _caps;
        [SerializeField] private GameObject[] _shirts;
        [SerializeField] private GameObject[] _pants;

        [Header("Profession Suits")] 
        [SerializeField] private GameObject[] _suits;
        private readonly Dictionary<string, GameObject> _professionSuits = new();

        public void Initialize(Gender gender, string characterName)
        {
            _gender = gender;
            name = characterName;
        }

        private void Awake()
        {
            foreach (var suit in _suits)
            {
                var professionName = suit.name.Split('_')[0];
                _professionSuits.Add(professionName, suit);
            }
        }
    }
}