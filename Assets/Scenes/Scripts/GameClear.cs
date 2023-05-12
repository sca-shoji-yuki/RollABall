using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameClear : MonoBehaviour
{
    public Text gameClearMessage;
    Transform myTransform;
    bool isGameClear = false;

    void Start()
    {
        myTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (myTransform.childCount == 0)
        {
            gameClearMessage.text = "Game Clear";
            Time.timeScale = 0f;
            isGameClear = true;
        }

        if(isGameClear && Input.GetButtonDown("Submit"))
        {
            Time.timeScale = 1f;

            SceneManager.LoadScene("Play");
        }
    }
}
