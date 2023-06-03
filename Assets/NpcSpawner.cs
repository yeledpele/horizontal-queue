using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcSpawner : MonoBehaviour
{
    // Assign your NPC Prefab and NPC Data in the Inspector
    public GameObject npcPrefab;
    public List<NpcData> npcDatas;

    // This will be used to set the spacing in the Inspector
    [Range(1, 10)]
    public int npcSpacing = 2;

    // Set the spawn start position
    public Vector2 spawnStartPosition;

    // The currently selected NPC
    public static Npc currentNpc = null;

    private void Start()
    {
        SpawnNPCs();
    }
    public void SpawnNPCs()  // Change access modifier here
    {
        // First, destroy any existing NPCs
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < npcDatas.Count; i++)
        {
            // Calculate the new spawn position
            Vector2 spawnPosition = spawnStartPosition + new Vector2(i * npcSpacing, 0);

            // Instantiate a new NPC object and set its position
            GameObject newNPC = Instantiate(npcPrefab, spawnPosition, Quaternion.identity, transform);
            newNPC.name = "NPC " + (i + 1); // For easier debugging

            // Assign the NPC data
            Npc npcComponent = newNPC.GetComponent<Npc>();
            if (npcComponent != null)
            {
                npcComponent.data = npcDatas[i];
                npcComponent.locationInQueue = i;
            }
            else
            {
                Debug.LogError("No Npc component found on NPC prefab.");
            }
        }
    }

}
