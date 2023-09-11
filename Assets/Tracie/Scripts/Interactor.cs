using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// tt:  singleton interactor implements interface IInteract, allowing player to press I to engage in interactions using the input system. 
/// </summary>
public  class Interactor : MonoBehaviour, IInteract
{
    private static Interactor instance;
    private void Awake()
    {
        if (instance != null && instance != this) { Destroy(this); return; }
        instance = this;
        isInteractPressed = false; 
    }
    public static Interactor GetInstance()
    {
        return instance;
    }
    [Header("Interactor Configurations")]
    [SerializeField] private GameObject player;
    [SerializeField] private bool isInteractPressed; 


    private KeyCode interactKey = KeyCode.I;

 
    private void Update()
    {
        GetInteractPressed(); 
    }
/// <summary>
/// THIS WORKS BUT SHOULD RETURN FALSE OTHERWISE INSTEAD OF GKU BECAUSE
/// OF TIED FUNCTIONALITIES TO DIALOGUE TRIGGER
/// </summary>
    public void GetInteractPressed()
    {
        if (Input.GetKeyDown(interactKey))
        {
           isInteractPressed = true;
            Debug.Log("Interaction engaged"); 
        }
        if(Input.GetKeyUp(interactKey))
        {
            isInteractPressed = false; 
        }
    }
  
}
