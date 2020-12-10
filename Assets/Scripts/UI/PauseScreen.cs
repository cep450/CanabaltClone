using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//PURPOSE: This script is to pause the screen 
//USAGE: this is attatched to the onClick on the pause button
public class PauseScreen : MonoBehaviour
{   //float pendingFreezeDuration = 0f;
   // public float duration = 1f; // how long until the pause is inititated
    public static bool isGamePaused =  false; // is the screen paused already? Made static so it can be accessed within multiple scripts
    [SerializeField] GameObject pauseMenu; //AKA PAUSE PANEL - cleaner way of making variables unneccesary for other classes to see available(?)
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused)
            {
                ResumeGame();
            }
            else 
            {
                PauseGame();
            }
        }
        
    }
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f; // HARK! TIME HAS RESUMED. WE HAVE RETURNED TO SUFFERING ;-;
        isGamePaused = false;
    }
    public void PauseGame() //stop time 
    {
        Debug.Log("VS says Pog you made it work"); 
        pauseMenu.SetActive(true);
        Time.timeScale = 0f; // STOP THE CLOCK TIME HAS DIED!!!!
        isGamePaused = true;
    }
    /*
     if (pendingFreezeDuration < 0 && !isGamePaused) // if the screen is not frozen and its pending freeze duration, start the coroutine
         {
             StartCoroutine(DoFreeze());
         }

     public void Freeze() // function that activates freeze, can be used in any other script = assign this to the button OnClick;
     {
         pendingFreezeDuration = duration;
     }

     public void PauseScrn()// assign this fun
     {
         Freeze();
     }

     IEnumerator DoFreeze()
     {
         isGamePaused = true;
         var original = Time.timeScale;
         Time.timeScale = 0;

         yield return new WaitForSecondsRealtime(duration);//always use reltime so this pause is independent of all time loops in scene 

         Time.timeScale = original;
         pendingFreezeDuration = 0;
         isGamePaused = true;
     }
    */
}
