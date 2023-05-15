using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed = 80f;
    public float boostMultiplier = 2f; // �̵� �ӵ��� �� ��� ������Ű�� ���

    void Update()
    {
        float currentSpeed = speed; // ���� �ӵ��� ������ ����

        // left shift Ű�� ���ȴ��� üũ�Ͽ� �ӵ� ����
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed *= boostMultiplier; // �̵� �ӵ��� �� ��� ������Ŵ
        }

        // ī�޶� �̵�
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
