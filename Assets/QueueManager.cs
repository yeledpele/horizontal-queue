using UnityEngine;
using System.Collections;

public class QueueManager : MonoBehaviour
{
    public NpcSpawner npcSpawner; // The NPC spawner
    public float eraseInterval = 5f; // The time interval to erase the first NPC

    private float timer;

    private void Start()
    {
        timer = eraseInterval;
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            // Reset the timer
            timer = eraseInterval;

            // Remove the first NPC in the queue
            EraseFirstNpc();
        }
    }

    private void EraseFirstNpc()
    {
        if (npcSpawner.transform.childCount > 0)
        {
            // Destroy the first NPC game object
            Destroy(npcSpawner.transform.GetChild(0).gameObject);

            // Wait a frame for the changes to take effect
           // StartCoroutine(ShiftRemainingNPCs());
        }
    }

    private IEnumerator ShiftRemainingNPCs()
    {
        // Wait for end of frame to ensure all children have been updated
        yield return new WaitForEndOfFrame();

        // Shift the remaining NPCs down the queue
        for (int i = 0; i < npcSpawner.transform.childCount; i++)
        {
            Transform child = npcSpawner.transform.GetChild(i);
            child.position = new Vector3(i * npcSpawner.npcSpacing, 0, 0);
            Npc npcComponent = child.GetComponent<Npc>();
            if (npcComponent != null)
            {
                npcComponent.locationInQueue--;
            }
        }

        // Reset color if the NPC destroyed was the current one
        if (NpcSpawner.currentNpc != null && NpcSpawner.currentNpc.locationInQueue < 0)
        {
            NpcSpawner.currentNpc = null;
        }
    }

}
