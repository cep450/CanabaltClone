using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//PURPOSE: To test how Death UI works out
//USAGE: Place this code on the player to instantiate a panel that showcases the death screen
public class DeathUITest : MonoBehaviour
{
    public Vector2 moveLeft;
    public int runDistance; //tracks how much youve moved 
    public Text distanceText;
    public GameObject gameOverPanel;
    public GameObject winPanel;
    public PlayerRunning playerRun;
    public GameObject distanceRan; // score on top right 
    
    bool deathMsgWasSet = false; //only set the death message once


    // Start is called before the first frame update
    void Start()
    {
        distanceRan.GetComponent<Text>().text = "0";
        gameOverPanel.SetActive(false);
        winPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        distanceRan.GetComponent<Text>().text = playerRun.distanceTotal.ToString("F0") + "m";
     

    }
    //If I enter a trigger and DIE!!!
    public void OnTriggerEnter2D(Collider2D activator)
    {
        Debug.Log("youve hit me! :(");
        if (activator.gameObject.tag.StartsWith("deathTrigger"))
        {

            Debug.Log("youve hit me! :(");
            //you die!!!! >:^)))
            gameOverPanel.SetActive(true);//activate THE GAME OVER panel 

            //are we in the proc scene or static scene?
            if(activator.gameObject.tag.Equals("deathTriggerProc")) {
                //proc scene
                if(!deathMsgWasSet) {
                    DeathTrigger deathTrigger = activator.gameObject.GetComponent<DeathTrigger>();
                    string deathMessage = deathTrigger.getDeathMessage();
                    distanceText.text = "You ran " + playerRun.distanceTotal + "m before " + deathMessage + ".";//in that panel showcase the score + the death message 
                    deathMsgWasSet = true;
                }
                
            } else {
                //static scene
                distanceText.text = "You ran " + playerRun.distanceTotal + "m before hitting a wall and tumbling to your death"  + ".";//in that panel showcase the score + the death message 
            }

        }
        if (activator.gameObject.tag == "Win")
        {
            Debug.Log("youve hit me NICELY this time");
            //you WIN!!!! :^)))
            winPanel.SetActive(true);//activate THE WIN panel 
          
        }


    }

}
