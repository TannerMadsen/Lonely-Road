using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScript : MonoBehaviour
{
    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController fpsMoveScript;
    public GameObject guns;
    public GameObject CrossHair;
    public GameObject EndScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(){
        Time.timeScale = 0;
        fpsMoveScript.enabled = false;
        guns.SetActive(false);
        CrossHair.SetActive(false);
        EndScreen.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
