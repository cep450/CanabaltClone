using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathTriggerBehavior : MonoBehaviour
{
    public Vector2 moveLeft;
    public DeathUITest deathUI;
    public Text distanceText;
    public GameObject gameOverPanel;
    // Start is called before the first frame update
    void Start()
    {
        gameOverPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*public void OnCollisionEnter2D(Collision2D activator)
    {
        Debug.Log("youve hit me! :(");
        if (activator.gameObject.tag == "Player")
        {
            //you die!!!! >:^)))
          
            gameOverPanel.SetActive(true);//activate a panel 
            distanceText.text = "You ran" + deathUI.runDistance + "before hitting a wall and tumbling to your death";//in that panel showcase the score + the death message 

        }

    }*/
}
