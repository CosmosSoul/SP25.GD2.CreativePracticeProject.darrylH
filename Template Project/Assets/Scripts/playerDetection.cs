using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class playerDetection : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] songs = new AudioClip[5];
    public TextMeshProUGUI textboxText;
    bool isPlayerInRange = false;

    private string[] dialogue4 = {
        "Samwise: What's good D.",
        "Dillon: Word to the wise! What it do bro. How you living?",
        "Samwise: We good. How you? How was that BSU event yesterday?",
        "Dillon: I'm chillin. Event was aight. Food was trash, but there were some interesting talks. And all the fine thangs in attendance didn't hurt either!",
        "Samwise: Or word?! I should have gone.",
        "Dillon: You know you just wasn't talking to anyone but Kayla if you'd gone. That girl got your whole mind rent-free!",
        "Samwise: I mean, at least i know what I want, right!",
        "Dillon: That's cool, but until she knows. You gotta live your life right?",
        "Samwise: Maybe, so what was the talk about?",
        "Dillon: It was about the need for Black history month.",
        "Samwise: Yeah, its crazy that people still have to justify it's existence!",
        "Dillon: Oh word. You think so?",
        "Samwise: Yeah, its like if we don't have black history month, then who's going to advocate for the contributions of black people to this success and development of this entire country. Not to mention how that influence extends out to the rest of the world.",
        "Dillon: I mean you're not wrong, but …",
        "Samwise: Like can you imagine a world where we don't have black history month. Do you think schools will willingly teach us about the real black panthers, and james baldwin and jim crow, and stokely carmichael. Otherwise we'll just keep getting the same MLK i have a dream and Malcom X, by any means necessary lectures over and over again.",
        "Dillon: Who is Jim Crow?",
        "Samwise: Bruh..",
        "Dillon: Hah, im playin…There was a time though, when even those boring MLK lectures were a luxury. You don't think that's progress?",
        "Samwise: I mean, it is. But how much further is there to go?",
        "Dillon: Well, the talk was actually about how having a black history month actually does more harm than help. Removing black history month could be how things go further.",
        "Samwise: Wait what? What do you mean?",
        "Dillon: The fact that black history month exists at all as this isolated time limited period is good as an annual reminder of the contributions of black people. But they were saying in the talk how it also, by definition, perpetuates the marginalization of us as a people. Our history is this separate peripheral thing apart from America as a whole that demands separate attention.",
        "Samwise: Nahh, but if there's no black history month then when will our people get their due.",
        "Dillon: They can get it…whenever",
        "Samwise: D, I'm serious. Why are you just whenever-ing this.",
        "Dillon: My dude. I actually mean whenever. They should get their due WHENEVER. Any day, any month, any season, any time of year, it should be appropriate to talk about these figures, these leaders of AMERICAN history. Not just during one month nor in the context of one people.",
        "Samwise: Oh, that's what you meant.",
        "Dillon: Yeah, the speaker made it sound good. But maybe BHM is only what it is because it doubles as an instrument of marginalization.",
        "Samwise: Makes you think about what the symbolism of Obama's presidency means?",
        "Dillon: Word!",
        "Samwise: Is it possible to for a marginalized people to achieve from within a system engineered against them?",
        "Dillon: Is it possible for someone to wise up from within kayla's spell of influence?",
        "Samwise: Hah! If Obama can do all that, then can't I figure out Kayla?",
        "Dillon: Maybe it's not all up to. Maybe its more up to the system.",
        "Samwise: Form follows function",
        "Dillon: The system chooses",
        "Samwise: …so you tryin to say I aint getting Kayla?",
        "Dillon: Hate to break it to you, but you probably won't be able to do much... she might still choose you if you play your cards right though."
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
            if (currentDialogueIndex < dialogue4.Length)
            {
                textboxText.text = dialogue4[currentDialogueIndex];
            }
      
            else if (currentDialogueIndex == dialogue4.Length)
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
            textboxText.text = dialogue4[currentDialogueIndex];
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

         private void PlayRandomSong()
         {
        if (songs.Length > 0)
        {
            int randomIndex = Random.Range(0, songs.Length);
            audioSource.clip = songs[randomIndex];
            audioSource.Play();
        }
    }
}

