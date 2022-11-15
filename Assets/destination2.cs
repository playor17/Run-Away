using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destination2 : MonoBehaviour
{
    [SerializeField] Camera Camera;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Player")
        {
            Vector3 position = Camera.transform.localPosition;
            position.x += 23;
            Camera.transform.localPosition = position;
        }
    }
}
