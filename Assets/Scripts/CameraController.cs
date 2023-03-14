using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform       target;
    private float           distance;

    private void Awake() {
        distance = Vector3.Distance(transform.position, target.position);
    }

    //플레이어를 움직이는 Update 함수가 실행 된 후 카메라를 이동하기위해 LateUpdate를 이용
    private void LateUpdate() {
        if(target == null) return;
        // rotation에 distance를 왜 곱해주는지 질문하기
        transform.position = target.position + transform.rotation * new Vector3(0, 0, -distance);
    }
}
