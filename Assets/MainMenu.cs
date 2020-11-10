using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//Purpose: houses all the actions the buttons in the main menu does;
//Usage: place this on a menuManager gameobject that you drag into the scene
public class MainMenu : MonoBehaviour
{
    //assign all in inspector
    public GameObject optionsPanel;
    public GameObject aboutPanel;
    public GameObject quitPanel;
    public GameObject leaderboardPanel;
    public GameObject achievementsPanel;
    public GameObject leadLocalPanel;
    public GameObject leadFriendsPanel;
    public GameObject leadAllTimePanel;
    public GameObject graphicsSettings;
    public GameObject soundSettings;
    public GameObject gameplaySettings;

  
    

    // Start is called before the first frame update
    void Start()
    {
        optionsPanel.SetActive(false);
        aboutPanel.SetActive(false);
        quitPanel.SetActive(false);
        leaderboardPanel.SetActive(false);
        achievementsPanel.SetActive(false);
        leadAllTimePanel.SetActive(false);
        leadFriendsPanel.SetActive(false);
        leadLocalPanel.SetActive(false);
        graphicsSettings.SetActive(false);
        soundSettings.SetActive(false);
        gameplaySettings.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BackButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void OptionsBackButton()
    {
        optionsPanel.SetActive(true);
        graphicsSettings.SetActive(false);
        soundSettings.SetActive(false);
        gameplaySettings.SetActive(false);
    }



    public void Options()
    {
        optionsPanel.SetActive(true);
    }
    public void SoundSettings()
    {
        graphicsSettings.SetActive(false);
        soundSettings.SetActive(true);
        gameplaySettings.SetActive(false);
        optionsPanel.SetActive(false);
    }
    public void GraphicsSettings()
    {
        graphicsSettings.SetActive(true);
        soundSettings.SetActive(false);
        gameplaySettings.SetActive(false);
        optionsPanel.SetActive(false);
    }
    public void GameplaySettings()
    {
        graphicsSettings.SetActive(false);
        soundSettings.SetActive(false);
        gameplaySettings.SetActive(true);
        optionsPanel.SetActive(false);
    }

    public void About()
    {
        aboutPanel.SetActive(true);
    }
    public void Quit()
    {
        quitPanel.SetActive(true);
    }
    public void LeaderBoard()
    {
        leaderboardPanel.SetActive(true);
        leadLocalPanel.SetActive(true);
       
    }
    public void LeaderBoardAllTime()
    {
        leadLocalPanel.SetActive(false);
        leadFriendsPanel.SetActive(false);
        leadAllTimePanel.SetActive(true);

    }
    public void LeaderBoardFriends()
    {
        leadLocalPanel.SetActive(false);
        leadFriendsPanel.SetActive(true);
        leadAllTimePanel.SetActive(false);

    }
    public void Achievements()
    { 
        achievementsPanel.SetActive(true);
    }
   

}
