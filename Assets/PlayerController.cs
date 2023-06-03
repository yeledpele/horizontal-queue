using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Transform _transform;
    private Vector2 moveDirection;
    public float speed = 10.0f;
    public int Facing = 1;

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        moveDirection = new Vector2(moveHorizontal, moveVertical);

        if (Mathf.Abs(moveHorizontal) > 0.0f)
        {
            var horizontalSign = (int)Mathf.Sign(moveHorizontal);
            Facing = -horizontalSign;
        }

        // Ensure that this script only controls its own GameObject
        _transform.position += (Vector3)moveDirection*speed*Time.deltaTime;

        var scale = _transform.localScale;
        scale.x = Facing;
        _transform.localScale = scale;
    }

    private void Awake()
    {
        _transform = GetComponent<Transform>();
    }
}
