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
    private KeyCode interactKey = KeyCode.I;


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
            if(Input.GetKeyDown(interactKey))
                // REFERENCE ISSUE  if(Interactor.GetInstance().GetInteractPressed())
                {
                Debug.Log(inkJSON.text); 
                 }
        }
        else
        {
            visualCue.SetActive(false);
        }
    }
}
