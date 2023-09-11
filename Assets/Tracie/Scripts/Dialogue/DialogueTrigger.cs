using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    // visual cue appears when player in collider radius 
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON; 
    private bool playerInRange;

    private void Awake()
    {
        playerInRange = false;
        visualCue.SetActive(false); 
    }

    private void Update()
    {
        ShowVisualCue(); 
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
         if(collider.gameObject.tag == "Player")
        {
            playerInRange = true; 
        }
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            playerInRange= false;
        }
    }

    private void ShowVisualCue()
    {
        if(playerInRange)
        {
            visualCue.SetActive(true);
        }
        else
        {
            visualCue.SetActive(false);
        }
    }
}
