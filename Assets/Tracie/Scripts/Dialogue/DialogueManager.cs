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

    private void Start()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false); 
    }

    public void EnterDialogueMode(TextAsset inkJSON)
    {

    }
}
