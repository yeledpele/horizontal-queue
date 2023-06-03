using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    private Vector2 moveDirection;

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        moveDirection = new Vector2(moveHorizontal, moveVertical);

        // Ensure that this script only controls its own GameObject
        transform.position += (Vector3)moveDirection * speed * Time.deltaTime;
    }
}
