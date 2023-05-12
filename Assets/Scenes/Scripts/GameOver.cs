using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour 
{
    public Text gameOverMessage;
    bool isGameOver = false;

    void Update()
    {
        if(isGameOver && Input.GetButtonDown("Submit"))
        {
            SceneManager.LoadScene("Play");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        gameOverMessage.text = "Game Over";
        Destroy(collision.gameObject);
        isGameOver = true;
    }
}
