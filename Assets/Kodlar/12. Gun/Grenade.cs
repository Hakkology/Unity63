using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float delay = 3f;
    float countdown;
    bool hasExploded = false;

    public GameObject explosionEffect;
    public ParticleSystem explosion;

    void Start(){
        countdown = delay;
    }

    void Update(){
        countdown -= Time.deltaTime;
        if(countdown <= 0f && !hasExploded){
            hasExploded = true;
            Explode();
        }
    }

    void Explode(){
        Debug.Log("BOOM!");

        explosion.Play();
        explosion.Stop();
        explosion.Clear();
        explosion.Emit(2000);
        // explosion.main.spee
        Instantiate (explosionEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}