using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime; 
public class DialogueManager : MonoBehaviour
{
    private static DialogueManager instance;
    private void Awake()
    {
        if (instance != null && instance != this) { Destroy(this); return; }
        instance = this;
    }
    public static DialogueManager GetInstance()
    {
        return instance;
    }

    [Header("Dialogue UI Configurationa")]
    [SerializeField] private GameObject dialoguePanel; 
    [SerializeField] private TextMeshProUGUI dialogueText;

    private Story currentStory;
    private bool dialogueIsPlaying;

    private KeyCode submitKey = KeyCode.S; 
    private void Start()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false); 
    }

    private void Update()
    {
        // return right away if dialogue isnt playing
        if(!dialogueIsPlaying)
        {
            return; 
        }
        // handle continuing to the next line in the dialogue when submit is pressed 
       // exhibit b 
        if(Input.GetKeyDown(submitKey))
        {
            ContinueStory(); 
        }

    }

    public void EnterDialogueMode(TextAsset inkJSON)
    {
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);
        ContinueStory(); 
    }
    /// <summary>
    ///  empty ink json file passed in 
    /// </summary>
    private void ExitDialogueMode()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = ""; 
    }


    private void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            // somewhat like popping a line out of a stack
            dialogueText.text = currentStory.Continue();
        }
        else
        {
            ExitDialogueMode();
        }
    }
}
