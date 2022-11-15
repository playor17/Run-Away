using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int _speed = 5;

    public AudioClip audioItem;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveControl();
    }

    void moveControl()
    {
        float xMove = Input.GetAxis("Horizontal") * _speed * Time.deltaTime; //x
        float yMove = Input.GetAxis("Vertical") * _speed * Time.deltaTime; //y
        this.transform.Translate(new Vector3(xMove, yMove, 0));

        Vector3 worldpos = Camera.main.WorldToViewportPoint(this.transform.position);
        if (worldpos.x < 0.025f) worldpos.x = 0.025f;
        if (worldpos.y < 0.05f) worldpos.y = 0.05f;
        if (worldpos.x > 0.975f) worldpos.x = 0.975f;
        if (worldpos.y > 0.95f) worldpos.y = 0.95f;
        this.transform.position = Camera.main.ViewportToWorldPoint(worldpos);
    }

    private void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.name == "destination1")
        {
            transform.position = new Vector3(1, 0, 0);
        }

        if (collider.gameObject.name == "item")
        {
            Debug.Log("Item Detected");
            _speed = _speed + 2;
            Destroy(collider.gameObject);
            PlaySound("ITEM");
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
            case "ITEM":
                audioSource.clip = audioItem;
                break;
        }
        audioSource.Play();
    }
}
