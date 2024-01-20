using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LevelScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 5.0f;
        GameManager.points = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickPlayAgain() {
        SceneManager.LoadScene("LevelScene");
    }

    public void ClickMainMenu() {
        SceneManager.LoadScene("MainMenuScene");
    }
}
