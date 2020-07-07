using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickup : MonoBehaviour
{
    public GameObject Target;
    public GameObject Gun;
    public bool SpecialGun;
    // Start is called before the first frame update
    void Start()
    {
        if(SpecialGun){
            Gun.GetComponentInChildren<GunScript>().enabled = false;
            Gun.GetComponentInChildren<Animator>().enabled = false;
        }else{
            Gun.GetComponent<GunScript>().enabled = false;
            Gun.GetComponent<Animator>().enabled = false;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other){
        if(other.tag == "Player"){
            Gun.layer = 9;
            foreach(Transform child in this.gameObject.GetComponentsInChildren<Transform>()){
                child.gameObject.layer = 9;
            }
            if(SpecialGun){
                Gun.GetComponentInChildren<GunScript>().enabled = true;
                Gun.GetComponentInChildren<Animator>().enabled = true;
            }else{
                Gun.GetComponent<GunScript>().enabled = true;
                Gun.GetComponent<Animator>().enabled = true;
            }
            Gun.transform.parent = Target.transform;
            Target.GetComponent<WeaponSwitching>().SelectWeapon();

            Destroy(this.gameObject);
        }
        //Debug.Log(other.name);

    }
}
