using System;
using QueueGame.Components;
using QueueGame.Data;
using QueueGame.Enums;
using UnityEngine;
using Random = UnityEngine.Random;

namespace QueueGame.Managers
{
    public class QueueGenerator
        : MonoBehaviour
    {
        public static QueueGenerator Instance { get; private set; }
        public static bool Exists => Instance != null;

        [SerializeField] private Transform _queueRoot;
        [SerializeField] private GameObject _characterPrefab;
        [SerializeField] private NameDictionary _nameDictionary;
        public Transform QueueRoot => _queueRoot;
        public GameObject CharacterPrefab => _characterPrefab;

        public float SpacingX = 0.5f;
        public float Spacing = 1.5f;
        public int TotalParticipants = 10;

        private void Awake()
        {
            if (Instance != null)
                throw new InvalidOperationException($"singleton instance already exists: type={GetType().Name}");

            Instance = this;
            GenerateQueue();
        }

        private void GenerateQueue()
        {
            Debug.Log("GeneratingQueue");
            CharacterPrefab.SetActive(false);

            for (var i = 0; i < TotalParticipants; i++)
            {
                var offset = Spacing + (i*Spacing);
                var npcInstance = Instantiate(CharacterPrefab, QueueRoot);

                var x = Random.Range(-SpacingX, +SpacingX);
                npcInstance.transform.localPosition = new Vector3(x, 0.0f, offset);
                npcInstance.SetActive(true);

                var characterGender = Random.Range(0.0f, 100.0f) > 50.0f ? Gender.Male : Gender.Female;
                var characterName = _nameDictionary.GetRandomName(characterGender);
                var character = npcInstance.GetComponent<Character>();
                character.Initialize(characterGender, characterName);
            }
        }
    }
}