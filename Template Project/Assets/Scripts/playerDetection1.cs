using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class playerDetection1 : MonoBehaviour
{
    public TextMeshProUGUI textboxText;
    bool isPlayerInRange = false;
    private int currentDialogueIndex = 0;
    private string[] dialogue1 = {
            "Class begins",
            "Professor: All right class, have you all completed your updates for this week?",
            "Everyone: …",
            "Professor: Hmm, we seem a bit sluggish today. Maybe we should recap together since I’m not getting much feedback from any of you. Have you completed your Brightspace module, Bhen?",
            "Bhen: …yes",
            "Professor: Have you posted your slack update with responses, Kasper?",
            "Keshia: Yes, I did mine on Sunday.",
            "Professor: Have you submitted all deliverables to the dropbox for this week, Brynda?",
            "Brynn: I thought you already confirmed that you received the submission okay, professor.",
            "Professor: Yes, yes. I have already seen it, but I wanted to hear you all responding. At least now I’m hearing some voices! Now then, has everyone completed this week’s brightspace module?",
            "Class: Yes!",
            "Professor: Has everyone submitted to the dropbox for this week?",
            "Class: Yes!",
            "Professor: Has everyone posted their Slack progress update?",
            "Class: Yes!",
            "Professor: Great! Now we’re warmed up. Now let’s take a look at the responses. Based on what you’ve posted, we can adjust the next assignment.",
            "Bhen: (whispers to Kasper) This is such a waste of time.",
            "Professor: …So let’s review. What did you all accomplish, what were your obstacles, and what is your plan for the next 2 weeks.",
            "Keshia: I completed the draft, met with the professor to review feedback and started integrating revisions.",
            "Professor: That sounds great, Kasper. Thanks for the update! Anyone else?",
            "Brynn: I reached all but one goal by this week’s deadline, so my 2 week plan is to catch up on the one thing I missed and get started this weekend for an early look at next week’s deliverable.",
            "Professor: That is so pro-active of you, Brynn. I’m looking forward to hearing more details at our next one-on-one meeting. Well done!",
            "Professor: What about obstacles? It sounds like you’re all making good progress so far, but let’s exchange some perspective on obstacles you’ve encountered and how you’ve been managing so far.",
            "Bhen: (under his breath) My biggest obstacle this term is this class…",
            "Professor: What was that! Did I hear some golden perspective from that side of the room!?",
            "Bhen: (avoids eye contact nervously)...",
            "Professor: Did you have something to share, Bhen?",
            "Bhen: …uhh I.. I kinda struggled with the brightspace submission..my uh..time management could have been better. How can I do better with this?",
            "Professor: Thank you for sharing, Bhen. Yeah, I know the feeling. Whenever I start grading your papers, I try to remind myself, this is only temporary, this is only temporary. This obstacle, too, shall pass",
            "Bhen: …",
         };
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
            if (currentDialogueIndex < dialogue1.Length)
            {
                textboxText.text = dialogue1[currentDialogueIndex];
            }
      
            else if (currentDialogueIndex == dialogue1.Length)
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
            textboxText.text = dialogue1[currentDialogueIndex];
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
