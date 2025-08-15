using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Z_ObjectMove : MonoBehaviour
{
    #region enum

    #endregion

    #region const

    #endregion

    #region public property

    #endregion

    public float MoveDistance = 2f; // �ړ������i�Б����j
    public float MoveSpeed = 2f; // �ړ����x

    #region private property

    #endregion

    private Vector3 startPosition; // ��Q���̏����ʒu

    #region public method

    #endregion

    #region private method

    #endregion


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
        transform.position = new Vector3(startPosition.x, startPosition.y, startPosition.z + offset);

    }
    
}
