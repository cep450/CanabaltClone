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
        //basically this all means that none of these panels are visible unless you call for them
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
        SceneManager.LoadScene("MainMenu");// go back to the mainmenu 
    }
    // in the options button once you change a specific setting itll take you to the specific ptions menu instead of the main menu 
    public void OptionsBackButton()
    {
        optionsPanel.SetActive(true);
        graphicsSettings.SetActive(false);
        soundSettings.SetActive(false);
        gameplaySettings.SetActive(false);
    }


    //activate options menu panel 
    public void Options()
    {
        optionsPanel.SetActive(true);
    }
    public void SoundSettings() //inside the options menu show the sound settings but turn off all the other options for now
    {
        graphicsSettings.SetActive(false);
        soundSettings.SetActive(true);
        gameplaySettings.SetActive(false);
        optionsPanel.SetActive(false);
    }
    public void GraphicsSettings()// inside the options menu lets open up the graphics settings but turn off the rest of the screens
    {
        graphicsSettings.SetActive(true);
        soundSettings.SetActive(false);
        gameplaySettings.SetActive(false);
        optionsPanel.SetActive(false);
    }
    public void GameplaySettings()// inside the options menu open up the gameplay settings but turn off the rest of the screens 
    {
        graphicsSettings.SetActive(false);
        soundSettings.SetActive(false);
        gameplaySettings.SetActive(true);
        optionsPanel.SetActive(false);
    }

    //activate about the game screen
    public void About()
    {
        aboutPanel.SetActive(true);
    }
    
    // activates quit button - sine this is an in browser game it just leads to a funny msg 
    public void Quit()
    {
        quitPanel.SetActive(true);
    }

    //activates leaderboard menu/ first thing you see is your best local runs 
    public void LeaderBoard()
    {
        leaderboardPanel.SetActive(true);
        leadLocalPanel.SetActive(true);
       
    }
    // using the tab at the bottom of the leaderboard menu you can now see the Best Runs Ever screen
    public void LeaderBoardAllTime()
    {
        leadLocalPanel.SetActive(false);
        leadFriendsPanel.SetActive(false);
        leadAllTimePanel.SetActive(true);

    }
    // using the tab at the bottom of the leaderboard menu you can now see the best runs of your friends on steam screen
    public void LeaderBoardFriends()
    {
        leadLocalPanel.SetActive(false);
        leadFriendsPanel.SetActive(true);
        leadAllTimePanel.SetActive(false);

    }

    //activates achievement button 
    public void Achievements()
    { 
        achievementsPanel.SetActive(true);
    }
   

}
