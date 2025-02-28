using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class playerDetection5 : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] songs = new AudioClip[5];
    public TextMeshProUGUI textboxText;
    bool isPlayerInRange = false;
    private int currentDialogueIndex = 0;
    private string[] dialogue5 = {
        "Rhonda: Hey girl, you heard the news?",
        "Daria: unfortunately! #notmypresident though!",  
        "Rhonda: Girl, stop saying that.",
        "Daria:  Why not, I didn’t vote for that clown. ",
        "Rhonda: But you still filing for your tax returns right?",
        "Daria:  I mean…aren’t you?",
        "Rhonda: I am, but I’m not acting like America and its newly ELECTED leader are the anti-christ.",
        "Daria: They aint?",
        "Rhonda: America has problems, but pretending like the country, not to mention implying all the people who voted the other way, are the enemy isn’t helping anything.",
        "Daria: So what is helping, Rhonda?",
        "Rhonda: I mean, I don’t know.",
        "Daria: Are we supposed to rally behind this person?",
        "Rhonda: Not exactly, but should we have rallied behind the other choice if they’d won?",
        "Daria: I don’t know, but it was a way better look than this!",
        "Rhonda: They didn’t have a plan either. How would they handle this war? How would they have dealt with immigration? How would they have worked on education? And the student loans? And civil rights? And health care? And housing? And..",
        "Daria:  All right all right. I don't know! But everyone can see… no, everyone been seen how bad this person is. So we go with the lesser of two evils and figure out. We always do.",
        "Rhonda: This is not figuring it out. This trajectory doesn’t feel like anything is being figured out. Things are getting worse. The division is getting worse. ",
        "Daria: Are we supposed to hold hands with the people supporting this administration. This racist, bigoted, discriminatory administration?",
        "Rhonda: I didn’t mean it that way.",
        "Daria: If we pretend this is just another election..If welcome such toxic perspectives back into the fold, if we normalize those ideas, behaviors and decisions, then what kind of ‘America’ do we have left?",
        "Rhonda: Yeah, that America sounds crazy. But it’s happening anyways. Do you think people on that side of the aisle are going to come to the middle? You think they’ll meet us half way?",
        "Daria:  Who do you think even cares about a fucking aisle?",
        "Rhonda: Daria…",
        "Daria: People are busy and tired and overworked and underpaid and are just trying to live a decent life despite the BS. We’re given an impossible situation with an endless list of problems and are expected to pick someone, to trust someone to lead solutions for all of them. This system is already a joke!",
        "Rhonda: You’re not wrong but didn’t you see the latest polls on the news?",
        "Daria:  Do you think all those news reports are helping?",
        "Rhonda: So I shouldn’t watch the news now?",
        "Daria: What about the people? What are people actually dealing with?",
        "Rhonda: The news doesn’t talk much about people? Heh, its usually just graphs and statistics?",
        "Daria: I wonder what percent of Americans would prefer to get rid of this joke of a electoral system?",
        "Rhonda: I bet they’ll never broadcast that graph.",
        "Daria: I didn’t mean to get so riled up, Rhon. I’m just so tired. It feels like there’s nothing we can do, and I’m so tired of the BS.",
        "Rhonda: I am too. Im tired and confused too. Maybe we’re not meant to understand things right now. Maybe it’s enough to just vent our perspectives and stay civil. To argue our perspective respectfully ",
        "Daria: Maybe you’re right. This election played out this way for real reason. People are unhappy with the status quo. I feel that. Maybe you’re right. But with all due respect, fuck that clown." ,
     };     
     
    // Start is called before the first frame update
    void Start()
    {
        textboxText.gameObject.SetActive(false);
       
    }

    // Update is called once per frame
    void Update()
    {
   
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Player has pressed F");
            currentDialogueIndex++;
            if (currentDialogueIndex < dialogue5.Length)
            {
                textboxText.text = dialogue5[currentDialogueIndex];
            }
      
            else if (currentDialogueIndex == dialogue5.Length)
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
            textboxText.text = dialogue5[currentDialogueIndex];
        }
    }

       void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                textboxText.gameObject.SetActive(true);
                isPlayerInRange = true;
                PlayRandomSong();
            }
        }
        void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                isPlayerInRange = false;
                audioSource.Stop();
                textboxText.gameObject.SetActive(false);
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
