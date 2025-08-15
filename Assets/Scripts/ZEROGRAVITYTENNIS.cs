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
    public float InitialSpeed = 5.0f; // ball�̏������x

    // Goal, out����F�Ώ�
    public GameObject GoalCube;
    public GameObject OutCube;

    #region private property

    #endregion

    // basic
    private float currentSpeed; // ball�̍��̑��x
    private Rigidbody rb;

    // Goal,out����
    private Vector3 initialPosition; // ball�̏����ʒu
    private Quaternion initialRotation; //ball�̏�����]

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
    }

    // �Œ莞�ԌĂяo���i�������Z�Ɠ����j
    void FixedUpdate()
    {
        // ���x�����i�P�ʃx�N�g���j�擾
        Vector3 velocity = rb.linearVelocity;
        Vector3 velocityDirection = velocity.normalized;

        // ���x�X�V�[�������������i��ɑ���5�Ői�s�����ɐi�ށj
        rb.linearVelocity = velocityDirection * currentSpeed;
    }

    // rb�����̃R���C�_�[�ƏՓ˂����Ƃ��̃C�x���g�֐�
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Goal")) // ���肪Goal
        {
            StartCoroutine(ActivateTemporarily(GoalCube, 2.0f)); // �S�[���G�t�F�N�g2�b�\��
        }
        else if (collision.gameObject.CompareTag("Out")) //���肪Out
        {
            ResetBall(); // ball�̑��x�ʒu��]�����Z�b�g

            StartCoroutine(ActivateTemporarily(OutCube, 2.0f));// �A�E�g�G�t�F�N�g2�b�\��
        }
    }

}
