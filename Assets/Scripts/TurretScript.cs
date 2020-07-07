using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
    public float SenseDistance;
    public float RotationSpeed;
    public Transform Player;
    private Vector3 _direction;
    private Quaternion _lookRotation;
    public float Cooldown;
    private float CooldownActual;
    public ParticleSystem MuzzleFlash;
    public float Damage;
    public float impactForce;
    public float MaxRange;
    public LayerMask Targetmask;
    public GameObject impactEffect;
    public AudioSource shootSound;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _direction = Player.position - this.transform.position;
        _direction.Normalize();
        _lookRotation = Quaternion.LookRotation(_direction);
        
        if((Player.position - this.transform.position).sqrMagnitude <= SenseDistance*SenseDistance){
            transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * RotationSpeed);
            if(CooldownActual >= Cooldown){
                Fire();
                CooldownActual = 0;
            }else{
                CooldownActual += Time.deltaTime;
            }
            if(CooldownActual > Cooldown){
                CooldownActual = Cooldown;
            }
        }
    }
    void Fire(){
        //Debug.Log("BANG!");
        MuzzleFlash.Play();
        shootSound.Play();
        
        //Debug.Log("BANG!");
        RaycastHit hit;
        if(Physics.Raycast(this.transform.position, this.transform.forward, out hit, MaxRange, Targetmask)){
            //Debug.Log(hit.transform.name);
            PlayerHealth target = hit.transform.GetComponent<PlayerHealth>();
            if(target != null){
                target.TakeDamage(Damage);
            }
            if(hit.rigidbody != null){
                hit.rigidbody.AddForce(-hit.normal * impactForce, ForceMode.Impulse);
            }
            Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
        }

    }
}
