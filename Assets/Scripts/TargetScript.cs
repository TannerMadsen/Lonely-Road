using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    public float health;
    // Start is called before the first frame update
    public void TakeDamage(float amount){
        health -= amount;
        if(health <= 0){
            Die();
        }
    }
    void Die(){
        Destroy(gameObject);
    }
}
