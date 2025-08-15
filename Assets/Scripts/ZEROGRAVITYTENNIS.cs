using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit.Inputs.Haptics;
using Unity.VisualScripting; // Hapticsの名前空間

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

    // スコアUI
    public TMP_Text ScoreText; // スコア表示用のTMPテキスト
    public TMP_Text BestScoreText; // ベストスコア表示用のTMPテキスト

    // ボールの速度加算用
    public float SpeedIncrement = 0.5f; // スコア加算ごとに増加する速度

    // 効果音
    public AudioSource AudioSource; // コンポ(音入れる箱)
    // 音源
    public AudioClip ScoreUpSound; // スコア加算時の効果音(音源)
    public AudioClip GameOverSound; //　アウト時の音
    public AudioClip RacketHitSound; // ヒット時の音

    // 振動
    public HapticImpulsePlayer LeftHapticPlayer; //振動プレイヤー(左右) 
    public HapticImpulsePlayer RightHapticPlayer;
    public bool VibrateLeftController = true; //振動させるかのフラグ(左右) 
    public bool VibrateRightController = true;



    #region private property

    #endregion

    // basic
    private float currentSpeed; // ballの今の速度
    private Rigidbody rb;

    // Goal,out判定
    private Vector3 initialPosition; // ballの初期位置
    private Quaternion initialRotation; //ballの初期回転

    // スコア表示用
    private int score = 0;
    private int bestScore = 0;

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

    // ゲームオーバー時にスコアを表示するコルーチン
    private IEnumerator DisplayFinalScore()
    {
        int finalScore = score; // 現在のスコアを表示用に使う
        score = 0; // スコアをリセット

        // GAME OVERを赤字で表示
        ScoreText.text = "GAME OVER";
        ScoreText.color = Color.red;

        yield return new WaitForSeconds(2.0f); // 2秒間停止してから次の処理

        // FINAL SCOREを白字で表示
        ScoreText.text = "FINAL SCORE:" + finalScore;
        ScoreText.color = Color.white;

        yield return new WaitForSeconds(2.0f); // 2秒間停止

        // 現在のスコアをリセット表示
        ScoreText.text = "SCORE:" + score;
        ScoreText.color = Color.white;
    }

    // VRコントローラーの振動を制御
    void VibrateControllers(float duration, float amplitude)
    {
        // フラグがtrue : 指定した時間と強さで振動させる
        if (VibrateLeftController)
        {
            LeftHapticPlayer.SendHapticImpulse(duration, amplitude);
        }

        if (VibrateRightController)
        {
            RightHapticPlayer.SendHapticImpulse(duration, amplitude);
        }


    }

// -----------------------
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

        // スコアUI
        ScoreText.text = "SCORE:" + score; // スコアテキストの初期表示設定（最初0）
        bestScore = PlayerPrefs.GetInt("BestScore:", 0); // (キー,値)を保存するAPI

        BestScoreText.text = "BEST SCORE:" + bestScore; // ベストスコアのテキストを更新
    }

    // 固定時間呼び出し（物理演算と同期）
    void FixedUpdate()
    {
        // 速度方向（単位ベクトル）取得
        Vector3 velocity = rb.linearVelocity;
        Vector3 velocityDirection = velocity.normalized;

        // 速度更新ー＞速さ＊方向（常に速さ5で進行方向に進む）
        rb.linearVelocity = velocityDirection * currentSpeed;

        // 速度(のユークリッド距離)が非常に遅い場合止まらせる
        if (velocity.magnitude < 0.1f)
        {
            rb.linearVelocity = Vector3.zero;
            return;
        } 
    }

    // rbが他のコライダーと衝突したときのイベント関数
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Goal")) // 相手がGoal
        {
            StartCoroutine(ActivateTemporarily(GoalCube, 2.0f)); // ゴールエフェクト2秒表示

            // スコアテキストがゲームオーバーの場合
            if (ScoreText.text == "GAME OVER")
            {
                score = 1;
                ScoreText.color = Color.white;
            }
            else
            {
                score++;
                currentSpeed += SpeedIncrement; // 速度加算
            }

            ScoreText.text = "SCORE:" + score; // スコアテキスト更新

            // ベストスコア更新時
            if (score > bestScore)
            {
                bestScore = score; // 更新
                PlayerPrefs.SetInt("BestScore", bestScore); // 永久保存API
                BestScoreText.text = "BEST SCORE" + bestScore; // テキスト表示
            }

            AudioSource.PlayOneShot(ScoreUpSound); // 音源再生（一階だけ）
        }
        else if (collision.gameObject.CompareTag("Out")) //相手がOut
        {
            ResetBall(); // ballの速度位置回転をリセット

            StartCoroutine(ActivateTemporarily(OutCube, 2.0f));// アウトエフェクト2秒表示

            StartCoroutine(DisplayFinalScore());  // Out時にスコア表示するコルーチンを呼び出す

            AudioSource.PlayOneShot(GameOverSound); // アウト時に一回だけ音源再生

        }
        else if (collision.gameObject.CompareTag("Racket")) // ラケットとの衝突
        {
            AudioSource.PlayOneShot(RacketHitSound); // ヒット音流す

            VibrateControllers(0.2f, 1.0f); // 0.2秒、強さ1fでコントローラーを振動
        }
    }

}
