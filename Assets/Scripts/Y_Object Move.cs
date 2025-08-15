using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Y_ObjectMove : MonoBehaviour
{

    public float MoveDistance = 2f; // �ړ������i�Б����j
    public float MoveSpeed = 2f; // �ړ����x

    private Vector3 startPosition; // ��Q���̏����ʒu




    // Start is called once 
    void Start()
    {
        startPosition = transform.position; // �����l�ʒu��ۑ�
    }

    // Update is called once per frame
    void Update()
    {
        // PingPong(�������A�l�͈̔�2f)-2f�@: (-2, 2)������
        float offset = Mathf.PingPong(Time.time * MoveSpeed, MoveDistance * 2) - MoveDistance;
        // �ʒu���L�q
        transform.position = new Vector3(startPosition.x, startPosition.y + offset, startPosition.z);

    }

}
