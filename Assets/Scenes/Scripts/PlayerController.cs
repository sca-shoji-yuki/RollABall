using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 20; //速さ
    public Text scoreText; //スコアUI
    public Text winText; //リザルトUI

    private Rigidbody rb; //Rigidbody
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        //rigidbodyを取得
        rb = GetComponent<Rigidbody>();

        //UI初期化
        score = 0;
        SetCountText();
        winText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        //入力を取得
        var moveHorizontal = Input.GetAxis("Horizontal"); //横
        var moveVertical = Input.GetAxis("Vertical");　//縦

        //移動方向
        var movement = new Vector3(moveHorizontal, 0, moveVertical);

        //Rigidbodyに力を与える
        rb.AddForce(movement * speed);

        if(transform.position.y < -10)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    //球がぶつかっときによばれる
    void OnTriggerEnter(Collider other)
    {
        //ぶつかったアイテムがPick Upだった場合
        if(other.gameObject.CompareTag("Pick Up"))
        {
            //非表示にする
            other.gameObject.SetActive(false);

            //スコア加算
            score = score + 1;

            //UI表示更新
            SetCountText();
        }
    }

    //UI表示更新
    void SetCountText()
    {
        //スコア表示更新
        scoreText.text = "Count" + score.ToString();

        //すべてのアイテムを取得
        if(score >= 12)
        {
            //リザルト表示更新
            winText.text = "You Win!";
        }
    }
}
