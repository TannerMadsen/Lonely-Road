using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PermanentScript : MonoBehaviour
{
    public static PermanentScript Instance;
    // Start is called before the first frame update
    void Awake ()   
       {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy (gameObject);
        }
      }
}
