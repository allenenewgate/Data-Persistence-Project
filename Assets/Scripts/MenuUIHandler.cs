using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuUIHandler : MonoBehaviour
{
    public Text highScoreText;
    public Text playerNameText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        UpdateHighScore();
        playerNameText.text = "Player Name: " + SaveSystem.playerName;
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }   
    
    public void UpdateHighScore()
    {
        highScoreText.text = $"High Score: {SaveSystem.highScoreName} - {SaveSystem.highScore}";
    }

    public void ChangePlayerName(string name)
    {
            Debug.Log(name);
            SaveSystem.playerName = name;
    }
}
