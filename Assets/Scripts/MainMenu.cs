using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Mainstuff;
    public GameObject Infostuff;
    public void ToInfo(){
        Mainstuff.SetActive(false);
        Infostuff.SetActive(true);
    }
    public void ToMenu(){
        Infostuff.SetActive(false);
        Mainstuff.SetActive(true);
        
    }
    public void PlayGame(){
        Time.timeScale = 1;
        SceneManager.LoadScene("LonelyRoad");
        
    }
    public void QuitToMenu(){
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
    public void Quit(){
        Application.Quit();
        Debug.Log("Quit!");
    }
}
