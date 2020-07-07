using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatlingRotate : MonoBehaviour
{
    public float DefaultSpeed;
    public float FireSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetButton("Fire1")){
            transform.Rotate(0,0,FireSpeed, Space.Self);
        }else{
            transform.Rotate(0,0,DefaultSpeed, Space.Self);
        }
    }
}
