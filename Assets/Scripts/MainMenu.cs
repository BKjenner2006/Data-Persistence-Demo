using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MainMenu : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    public GameObject NameInput;

    public void Start()
    {
        GameManager.Instance.LoadScore();
        ScoreText.text = "High Score: " + GameManager.Instance.HighScoreName + " " + GameManager.Instance.HighScore;
    }

    public void StartGame()
    {
        GameManager.Instance.UserName = NameInput.GetComponent<TMP_InputField>().text;
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
                EditorApplication.ExitPlaymode();
        #else
                Application.Quit();
        #endif
    }
}
