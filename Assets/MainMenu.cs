using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//Purpose: houses all the actions the buttons in the main menu does;
//Usage: place this on a menuManager gameobject that you drag into the scene
public class MainMenu : MonoBehaviour
{
    public GameObject optionsPanel;
    public GameObject aboutPanel;
    public GameObject quitPanel;
    public GameObject leaderboardPanel;
    public GameObject achievementsPanel;
    public GameObject leadLocalPanel;
    public GameObject leadFriendsPanel;
    public GameObject leadAllTimePanel;
    public bool leaderboardWorld;
    

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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BackButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Options()
    {
        optionsPanel.SetActive(true);
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
