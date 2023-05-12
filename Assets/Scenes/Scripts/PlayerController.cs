using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 20; //����
    public Text scoreText; //�X�R�AUI
    public Text winText; //���U���gUI

    private Rigidbody rb; //Rigidbody
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        //rigidbody���擾
        rb = GetComponent<Rigidbody>();

        //UI������
        score = 0;
        SetCountText();
        winText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        //���͂��擾
        var moveHorizontal = Input.GetAxis("Horizontal"); //��
        var moveVertical = Input.GetAxis("Vertical");�@//�c

        //�ړ�����
        var movement = new Vector3(moveHorizontal, 0, moveVertical);

        //Rigidbody�ɗ͂�^����
        rb.AddForce(movement * speed);

        if(transform.position.y < -10)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    //�����Ԃ����Ƃ��ɂ�΂��
    void OnTriggerEnter(Collider other)
    {
        //�Ԃ������A�C�e����Pick Up�������ꍇ
        if(other.gameObject.CompareTag("Pick Up"))
        {
            //��\���ɂ���
            other.gameObject.SetActive(false);

            //�X�R�A���Z
            score = score + 1;

            //UI�\���X�V
            SetCountText();
        }
    }

    //UI�\���X�V
    void SetCountText()
    {
        //�X�R�A�\���X�V
        scoreText.text = "Count" + score.ToString();

        //���ׂẴA�C�e�����擾
        if(score >= 12)
        {
            //���U���g�\���X�V
            winText.text = "You Win!";
        }
    }
}
