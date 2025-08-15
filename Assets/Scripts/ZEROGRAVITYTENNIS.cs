using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit.Inputs.Haptics;
using Unity.VisualScripting; // Haptics�̖��O���

public class ZEROGRAVITYTENNIS : MonoBehaviour
{
    #region enum

    #endregion

    #region const

    #endregion

    #region public property

    #endregion

    // basic
    public float InitialSpeed = 5.0f; // ball�̏������x

    // Goal, out����F�Ώ�
    public GameObject GoalCube;
    public GameObject OutCube;

    // �X�R�AUI
    public TMP_Text ScoreText; // �X�R�A�\���p��TMP�e�L�X�g
    public TMP_Text BestScoreText; // �x�X�g�X�R�A�\���p��TMP�e�L�X�g

    // �{�[���̑��x���Z�p
    public float SpeedIncrement = 0.5f; // �X�R�A���Z���Ƃɑ������鑬�x

    // ���ʉ�
    public AudioSource AudioSource; // �R���|(������锠)
    // ����
    public AudioClip ScoreUpSound; // �X�R�A���Z���̌��ʉ�(����)
    public AudioClip GameOverSound; //�@�A�E�g���̉�
    public AudioClip RacketHitSound; // �q�b�g���̉�

    // �U��
    public HapticImpulsePlayer LeftHapticPlayer; //�U���v���C���[(���E) 
    public HapticImpulsePlayer RightHapticPlayer;
    public bool VibrateLeftController = true; //�U�������邩�̃t���O(���E) 
    public bool VibrateRightController = true;



    #region private property

    #endregion

    // basic
    private float currentSpeed; // ball�̍��̑��x
    private Rigidbody rb;

    // Goal,out����
    private Vector3 initialPosition; // ball�̏����ʒu
    private Quaternion initialRotation; //ball�̏�����]

    // �X�R�A�\���p
    private int score = 0;
    private int bestScore = 0;

    #region public method

    #endregion


    #region private method

    #endregion

    // ball�̏�Ԃ����Z�b�g���郁�\�b�h
    private void ResetBall()
    {
        currentSpeed = InitialSpeed; // ��葬�x�������l�Ƀ��Z�b�g

        rb.linearVelocity = Vector3.zero; // ��~

        rb.angularVelocity = Vector3.zero; // ��]���~

        // ball�����Z�b�g�z�u
        transform.position = initialPosition;
        transform.rotation = initialRotation;
    }

    // �w�莞�ԕ\������R���[�`���i�t���[�����܂����������j
    private IEnumerator ActivateTemporarily(GameObject obj, float duration)
    {
        obj.SetActive(true); // �I�u�W�F�N�g�\��

        yield return new WaitForSeconds(duration); // �ҋ@�i���쌠��Unity�ɓn���j

        obj.SetActive(false); // �I�u�W�F�N�g���\��
    }

    // �Q�[���I�[�o�[���ɃX�R�A��\������R���[�`��
    private IEnumerator DisplayFinalScore()
    {
        int finalScore = score; // ���݂̃X�R�A��\���p�Ɏg��
        score = 0; // �X�R�A�����Z�b�g

        // GAME OVER��Ԏ��ŕ\��
        ScoreText.text = "GAME OVER";
        ScoreText.color = Color.red;

        yield return new WaitForSeconds(2.0f); // 2�b�Ԓ�~���Ă��玟�̏���

        // FINAL SCORE�𔒎��ŕ\��
        ScoreText.text = "FINAL SCORE:" + finalScore;
        ScoreText.color = Color.white;

        yield return new WaitForSeconds(2.0f); // 2�b�Ԓ�~

        // ���݂̃X�R�A�����Z�b�g�\��
        ScoreText.text = "SCORE:" + score;
        ScoreText.color = Color.white;
    }

    // VR�R���g���[���[�̐U���𐧌�
    void VibrateControllers(float duration, float amplitude)
    {
        // �t���O��true : �w�肵�����ԂƋ����ŐU��������
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
        rb = GetComponent<Rigidbody>(); // �R���|�擾
        currentSpeed = InitialSpeed;

        // Goal, out
        initialPosition = transform.position; // ball�̏����ʒu
        initialRotation = transform.rotation; // ball�̏�����]

        // Goal, out���ɃG�t�F�N�gCube���\��
        GoalCube.SetActive(false);
        OutCube.SetActive(false);

        // �X�R�AUI
        ScoreText.text = "SCORE:" + score; // �X�R�A�e�L�X�g�̏����\���ݒ�i�ŏ�0�j
        bestScore = PlayerPrefs.GetInt("BestScore:", 0); // (�L�[,�l)��ۑ�����API

        BestScoreText.text = "BEST SCORE:" + bestScore; // �x�X�g�X�R�A�̃e�L�X�g���X�V
    }

    // �Œ莞�ԌĂяo���i�������Z�Ɠ����j
    void FixedUpdate()
    {
        // ���x�����i�P�ʃx�N�g���j�擾
        Vector3 velocity = rb.linearVelocity;
        Vector3 velocityDirection = velocity.normalized;

        // ���x�X�V�[�������������i��ɑ���5�Ői�s�����ɐi�ށj
        rb.linearVelocity = velocityDirection * currentSpeed;

        // ���x(�̃��[�N���b�h����)�����ɒx���ꍇ�~�܂点��
        if (velocity.magnitude < 0.1f)
        {
            rb.linearVelocity = Vector3.zero;
            return;
        } 
    }

    // rb�����̃R���C�_�[�ƏՓ˂����Ƃ��̃C�x���g�֐�
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Goal")) // ���肪Goal
        {
            StartCoroutine(ActivateTemporarily(GoalCube, 2.0f)); // �S�[���G�t�F�N�g2�b�\��

            // �X�R�A�e�L�X�g���Q�[���I�[�o�[�̏ꍇ
            if (ScoreText.text == "GAME OVER")
            {
                score = 1;
                ScoreText.color = Color.white;
            }
            else
            {
                score++;
                currentSpeed += SpeedIncrement; // ���x���Z
            }

            ScoreText.text = "SCORE:" + score; // �X�R�A�e�L�X�g�X�V

            // �x�X�g�X�R�A�X�V��
            if (score > bestScore)
            {
                bestScore = score; // �X�V
                PlayerPrefs.SetInt("BestScore", bestScore); // �i�v�ۑ�API
                BestScoreText.text = "BEST SCORE" + bestScore; // �e�L�X�g�\��
            }

            AudioSource.PlayOneShot(ScoreUpSound); // �����Đ��i��K�����j
        }
        else if (collision.gameObject.CompareTag("Out")) //���肪Out
        {
            ResetBall(); // ball�̑��x�ʒu��]�����Z�b�g

            StartCoroutine(ActivateTemporarily(OutCube, 2.0f));// �A�E�g�G�t�F�N�g2�b�\��

            StartCoroutine(DisplayFinalScore());  // Out���ɃX�R�A�\������R���[�`�����Ăяo��

            AudioSource.PlayOneShot(GameOverSound); // �A�E�g���Ɉ�񂾂������Đ�

        }
        else if (collision.gameObject.CompareTag("Racket")) // ���P�b�g�Ƃ̏Փ�
        {
            AudioSource.PlayOneShot(RacketHitSound); // �q�b�g������

            VibrateControllers(0.2f, 1.0f); // 0.2�b�A����1f�ŃR���g���[���[��U��
        }
    }

}
