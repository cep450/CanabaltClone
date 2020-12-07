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
    


    // Start is called before the first frame update
    void Start()
    {
        gameOverPanel.SetActive(false);
        winPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(moveLeft);
            runDistance+=1; //distance increases when you move just to test if it takes in the score 
            //Debug.Log(runDistance);
        }
        if (Input.GetKey(KeyCode.A))
        {
            //Debug.Log(runDistance);
            transform.Translate(-moveLeft);
            runDistance+=1; //distance increases when you move just to test if it takes in the score 
        }

    }
    //If I enter a trigger and DIE!!!
    public void OnTriggerEnter2D(Collider2D activator)
    {
        Debug.Log("youve hit me! :(");
        if (activator.gameObject.tag == "deathTrigger")
        {

            DeathTrigger deathTrigger = activator.gameObject.GetComponent<DeathTrigger>();
            string deathMessage = deathTrigger.getDeathMessage();

            Debug.Log("youve hit me! :(");
            //you die!!!! >:^)))
            gameOverPanel.SetActive(true);//activate THE GAME OVER panel 
            distanceText.text = "You ran " + playerRun.distanceTotal + "m before " + deathMessage + ".";//in that panel showcase the score + the death message 

        }
        if (activator.gameObject.tag == "Win")
        {
            Debug.Log("youve hit me NICELY this time");
            //you WIN!!!! :^)))
            winPanel.SetActive(true);//activate THE WIN panel 
          
        }


    }

}
