using UnityEngine;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;

    public TMP_InputField nameText;
    public string playerName;
    public int bestScore = 0;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        Debug.Log(playerName);
        nameText.onValueChanged.AddListener(SaveName);
    }

    public void SaveName(string text)
    {
        playerName = nameText.text;
    }
}