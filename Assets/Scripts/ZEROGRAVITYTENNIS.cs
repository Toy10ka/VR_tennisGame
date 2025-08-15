using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZEROGRAVITYTENNIS : MonoBehaviour
{
    #region enum

    #endregion

    #region const

    #endregion

    #region public property

    #endregion

    // basic
    public float InitialSpeed = 5.0f; // ballの初期速度

    // Goal, out判定：対象
    public GameObject GoalCube;
    public GameObject OutCube;

    #region private property

    #endregion

    // basic
    private float currentSpeed; // ballの今の速度
    private Rigidbody rb;

    // Goal,out判定
    private Vector3 initialPosition; // ballの初期位置
    private Quaternion initialRotation; //ballの初期回転

    #region public method

    #endregion


    #region private method

    #endregion

    // ballの状態をリセットするメソッド
    private void ResetBall()
    {
        currentSpeed = InitialSpeed; // 一定速度を初期値にリセット

        rb.linearVelocity = Vector3.zero; // 停止

        rb.angularVelocity = Vector3.zero; // 回転を停止

        // ballをリセット配置
        transform.position = initialPosition;
        transform.rotation = initialRotation;
    }

    // 指定時間表示するコルーチン（フレームをまたいだ処理）
    private IEnumerator ActivateTemporarily(GameObject obj, float duration)
    {
        obj.SetActive(true); // オブジェクト表示

        yield return new WaitForSeconds(duration); // 待機（操作権をUnityに渡す）

        obj.SetActive(false); // オブジェクトを非表示
    }


    // Start is called once 
    void Start()
    {
        // basic
        rb = GetComponent<Rigidbody>(); // コンポ取得
        currentSpeed = InitialSpeed;

        // Goal, out
        initialPosition = transform.position; // ballの初期位置
        initialRotation = transform.rotation; // ballの初期回転

        // Goal, out時にエフェクトCubeを非表示
        GoalCube.SetActive(false);
        OutCube.SetActive(false);
    }

    // 固定時間呼び出し（物理演算と同期）
    void FixedUpdate()
    {
        // 速度方向（単位ベクトル）取得
        Vector3 velocity = rb.linearVelocity;
        Vector3 velocityDirection = velocity.normalized;

        // 速度更新ー＞速さ＊方向（常に速さ5で進行方向に進む）
        rb.linearVelocity = velocityDirection * currentSpeed;
    }

    // rbが他のコライダーと衝突したときのイベント関数
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Goal")) // 相手がGoal
        {
            StartCoroutine(ActivateTemporarily(GoalCube, 2.0f)); // ゴールエフェクト2秒表示
        }
        else if (collision.gameObject.CompareTag("Out")) //相手がOut
        {
            ResetBall(); // ballの速度位置回転をリセット

            StartCoroutine(ActivateTemporarily(OutCube, 2.0f));// アウトエフェクト2秒表示
        }
    }

}
