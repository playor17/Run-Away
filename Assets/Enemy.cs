using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform target;
    public AudioClip audioDamaged;
    AudioSource audioSource;

    public Transform Target 
    {
        get 
        { 
            return target;
        } 
        set 
        { 
            target = value;
        } 
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FollowTarget();        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.name == "Player")
        {
            Destroy(collider.gameObject);
            PlaySound("DAMAGED");
        }
    }

    private void FollowTarget()
    {
        if (target != null)
        {
            Vector3 targetPosition = target.position;
            Vector3 myPosition = transform.position;

            transform.position = Vector2.MoveTowards(transform.position, target.position, 1* Time.deltaTime);
        }
    }

    private void Awake()
    {
        this.audioSource = GetComponent<AudioSource>();
    }

    void PlaySound(string action)
    {
        switch (action)
        {
            case "DAMAGED":
                audioSource.clip = audioDamaged;
                break;
        }
        audioSource.Play();
    }
}
