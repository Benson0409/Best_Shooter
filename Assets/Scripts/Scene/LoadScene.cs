using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadScene : MonoBehaviour
{
    public void ReloadGame()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentScene);
        //恢復時間流動
        Time.timeScale = 1;
    }
    public void ExitGame()
    {
        Application.Quit();
        print("離開遊戲");
    }
}
