using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] int _speed;

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "destination1")
        {
            transform.position = new Vector3(1, 0, 0);
        }
    }
}
