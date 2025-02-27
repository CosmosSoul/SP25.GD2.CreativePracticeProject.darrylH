using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class playerDetection : MonoBehaviour
{

    public TextMeshProUGUI textboxText;
    bool isPlayerInRange = false;
    private string[] dialogue2 = {
        "Hello, how are you?",
        "I'm fine, thank you!",
        "What is your name?",
        "My name is John Doe.",
        "Nice to meet you, John Doe.",
    };
    private int currentDialogueIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Player has pressed F");
            currentDialogueIndex++;
            if (currentDialogueIndex < dialogue2.Length)
            {
                textboxText.text = dialogue2[currentDialogueIndex];
            }
      
            else if (currentDialogueIndex == dialogue2.Length)
            {
                textboxText.text = "press F to eavesdrop!";
                currentDialogueIndex = 0;
            }
            else
            {
                textboxText.text = "eavesdrop complete!";
                isPlayerInRange = false;
            }
        }
        else if (Input.GetKeyDown(KeyCode.R) && currentDialogueIndex > 0)
         {
            currentDialogueIndex--;
            textboxText.text = dialogue2[currentDialogueIndex];
        }
    }
         void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                isPlayerInRange = true;
            }
        }
        void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                isPlayerInRange = false;
            }
        }
}
