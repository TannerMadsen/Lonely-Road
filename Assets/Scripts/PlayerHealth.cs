using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters;


public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public float health;
    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController fpsMoveScript;
    public GameObject guns;
    public GameObject CrossHair;
    public GameObject DeathScreen;
    public bool Dead;
    public bool Paused;
    public GameObject PauseScreen;

    // Start is called before the first frame update
    public void TakeDamage(float amount){
        health -= amount;
        if(health <= 0){
            Die();
        }
    }
    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape) && !Dead){
            Pause();
        }
    }
    public void Pause(){
        Debug.Log("PAUSE");
        Paused = true;
        Time.timeScale = 0;
        fpsMoveScript.enabled = false;
        guns.SetActive(false);
        CrossHair.SetActive(false);
        PauseScreen.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void UnPause(){
        Debug.Log("UNPAUSE");
        Paused = false;
        Time.timeScale = 1;
        fpsMoveScript.enabled = true;
        guns.SetActive(true);
        CrossHair.SetActive(true);
        PauseScreen.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Die(){
        Dead = true;
        Time.timeScale = 0;
        fpsMoveScript.enabled = false;
        guns.SetActive(false);
        CrossHair.SetActive(false);
        DeathScreen.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

    }
}
