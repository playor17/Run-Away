using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class shelter : MonoBehaviour
{
    [SerializeField] GameObject clearPanel;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Player")
        {
            Debug.Log("End");
            clearPanel.SetActive(true);
            Time.timeScale = 0;
            AudioListener.volume = AudioListener.volume == 0 ? 1 : 0;
        }
    }
}
