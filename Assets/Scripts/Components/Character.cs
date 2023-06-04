using System.Collections.Generic;
using System.Linq;
using BinaryEyes.Common.Extensions;
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

            var hasBeard = CheckShouldHaveBeard();
            if (hasBeard)
                _maleBeards.GetRandom().SetActive(true);

            var hairs = _gender == Gender.Male ? _maleHair : _femaleHair;
            var shoes = _gender == Gender.Male ? _maleShoes : _femaleShoes;
            hairs.GetRandom().SetActive(true);
            shoes.GetRandom().SetActive(true);

            var profession = RandomizeProfession();
            if (!string.IsNullOrEmpty(profession))
                _professionSuits[profession].SetActive(true);
            else
                ActivateNormalClothes();
        }

        private void ActivateNormalClothes()
        {
            _scarves.GetRandom().SetActive(true);
            _chains.GetRandom().SetActive(true);
            _caps.GetRandom().SetActive(true);
            _shirts.GetRandom().SetActive(true);
            _pants.GetRandom().SetActive(true);

        }

        private string RandomizeProfession()
        {
            var hasProfession = Random.Range(0.0f, 100.0f) > 50.0f;
            if (!hasProfession)
                return string.Empty;

            return _professionSuits.Keys.ToList().GetRandom();
        }

        private bool CheckShouldHaveBeard()
        {
            if (_gender == Gender.Female)
                return false;

            return Random.Range(0.0f, 100.0f) > 75.0f;
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