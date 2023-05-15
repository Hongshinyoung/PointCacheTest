using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed = 80f;
    public float boostMultiplier = 2f; // 이동 속도를 두 배로 증가시키는 상수

    void Update()
    {
        float currentSpeed = speed; // 현재 속도를 저장할 변수

        // left shift 키가 눌렸는지 체크하여 속도 조절
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed *= boostMultiplier; // 이동 속도를 두 배로 증가시킴
        }

        // 카메라 이동
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * currentSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * currentSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= transform.right * currentSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * currentSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.position -= transform.up * currentSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.position += transform.up * currentSpeed * Time.deltaTime;
        }
    }
}
