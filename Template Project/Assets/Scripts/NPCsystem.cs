using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCsystem : MonoBehaviour
{
    public string[] dialogue = new string[] 
    {
        "Hello there!",
        "Welcome to my shop.",
        "How can I help you today?"
    };

    public int currentDialogueIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void NewDialogue(string text)
    {
        Debug.Log(text);
    }

    void NextDialogue()
    {
        currentDialogueIndex++;
        if (currentDialogueIndex < dialogue.Length)
        {
            NewDialogue(dialogue[currentDialogueIndex]);
        }
        else
        {
            Debug.Log("Dialogue finished");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            NewDialogue(dialogue[currentDialogueIndex]);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player has left the trigger");
        }
    }
}




