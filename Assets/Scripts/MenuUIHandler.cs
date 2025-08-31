using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class MenuUIHandler : MonoBehaviour
{
    public TextMeshProUGUI bestScoreText;
    public TextMeshProUGUI placeHolderText;
    public Button startButton;

    public SaveData saveDataScript;

    void Start()
    {
        bestScoreText.text = "Best Score : " + MenuManager.Instance.playerName + " : " + MenuManager.Instance.bestScore;
        startButton.interactable = false;
    }

    public void CheckTextChange(string text)
    {
        if(string.IsNullOrEmpty(text))
        {
            startButton.interactable = false;
            placeHolderText.text = "Enter Name...";
        }
        else
        {
            startButton.interactable = true;
            placeHolderText.text = "";
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}