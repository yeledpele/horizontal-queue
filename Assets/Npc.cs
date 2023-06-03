using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : MonoBehaviour
{
    public Transform target;
    public float speed = 1f;
    public float stoppingDistance = 1f;

    public NpcData data;
    public int locationInQueue;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = data.image;

        GameObject targetObject = GameObject.FindGameObjectWithTag("Target");
        if (targetObject != null)
        {
            target = targetObject.transform;
        }

        if (data.isPlayer)
        {
            gameObject.AddComponent<PlayerController>();
        }
    }

    void Update()
    {
        if (target != null)
        {
            // Get the direction to the target
            Vector2 direction = (target.position - transform.position).normalized;

            // Perform a Raycast in the direction of the target
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, speed * Time.deltaTime);

            // If the Raycast hits another NPC, stop moving
            if (hit.collider != null && hit.collider.gameObject != this.gameObject && hit.collider.CompareTag("Npc"))
            {
                return;
            }

            // If it's not hitting any other NPC, continue moving
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }

    void OnMouseDown()
    {
        if (NpcSpawner.currentNpc != null)
        {
            NpcSpawner.currentNpc.GetComponent<SpriteRenderer>().color = Color.white;
        }

        GetComponent<SpriteRenderer>().color = Color.red;
        NpcSpawner.currentNpc = this;
    }
}
