using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Movement    movement;
    private float       limitDeathY;

    private void Awake() {
        movement = GetComponent<Movement>();

        movement.MoveTo(Vector3.right);

        // 1.65 - 0.3 * 0.5 = 1.5
        limitDeathY = transform.position.y - transform.localScale.y * 0.5f;
    }

    private void Update() {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 direction = movement.MoveDirection == Vector3.forward ? Vector3.right : Vector3.forward;

            movement.MoveTo(direction);
        }

        if (transform.position.y < limitDeathY)
        {
            Debug.Log("GameOver");
        }
    }
}
