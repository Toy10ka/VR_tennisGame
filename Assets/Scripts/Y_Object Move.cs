using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Y_ObjectMove : MonoBehaviour
{

    public float MoveDistance = 2f; // 移動距離（片側分）
    public float MoveSpeed = 2f; // 移動速度

    private Vector3 startPosition; // 障害物の初期位置




    // Start is called once 
    void Start()
    {
        startPosition = transform.position; // 初期値位置を保存
    }

    // Update is called once per frame
    void Update()
    {
        // PingPong(総距離、値の範囲2f)-2f　: (-2, 2)を往復
        float offset = Mathf.PingPong(Time.time * MoveSpeed, MoveDistance * 2) - MoveDistance;
        // 位置を記述
        transform.position = new Vector3(startPosition.x, startPosition.y + offset, startPosition.z);

    }

}
