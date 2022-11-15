using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destination1 : MonoBehaviour
{
    [SerializeField] Camera Camera;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Player")
        {
            Debug.Log("des1");
            Vector3 position = Camera.transform.localPosition;
            position.x += 23;
            Camera.transform.localPosition = position;
        }
    }
}
