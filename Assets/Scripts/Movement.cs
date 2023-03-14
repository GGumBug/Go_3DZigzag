using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float   moveSpeed;
    private Vector3 moveDirection;

    //외부에서 moveDirection값을 확인 할수 있도록 get을 public으로 설정.
    public Vector3  MoveDirection => moveDirection;

    private void Update() {
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }

    public void MoveTo(Vector3 direction)
    {
        moveDirection = direction;
    }
}
