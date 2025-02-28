using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class playerDetection2 : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] songs = new AudioClip[5];
    public TextMeshProUGUI textboxText;
    bool isPlayerInRange = false;
    private int currentDialogueIndex = 0;
    private string[] dialogue2 = {
        "Desmond: Heyy what’s good, J. (daps up, J). Come in, how you living?  ",
        "Jurrian: what’s good whats good, I’ve been all right. How you?  ",
        "Desmond: I’m not bad, good to see you.  ",
        "Jurrriann: shoes off?  ",
        "Desmond: yeah, leave em there.  ",
        "Jurrian: Sorry, I’m late. How much did I miss?  ",
        "Desmond: Only a few minutes into the 1st quarter. You haven’t missed too much. Only a few BS calls so far.  ",
        "Jurrian: Heh, cool. I thought Ansem was coming?  ",
        "Desmond: You know he stay late. Always crushin on some new swipe.  ",
        "Jurian: Oh he’s been out there like that?  ",
        "Desmond: Yeah, ever since him and wifey broke up, he’s been out there heavy.  ",
        "Jurian: mm, maybe he’s…  ",
        "*doorbell rings*Desmond gets up to answer*  ",
        "Desmond: Yerrr  ",
        "Ansem: Yoo, what up D? What up J? How yall doing?  ",
        "Desmond: I’m aight. What’s good, with you though A. What time is it? Who you coming from?  ",
        "Ansem: (with a sly smirk) I meeeann, you know.  ",
        "Jurian: Oh word, I heard you out for 2 weeks with a sprained thumb from all that swiping!  ",
        "Ansem: Ha! you got jokes. Even at 2 weeks, I’d be tougher than these Knicks. You heard Johnson is out again?!  ",
        "Jurian: Yo, its crazy. He was just out, plays 2 games, and is out again. What are these dudes getting paid for?! Man, fuck the Knicks.  ",
        "So what are we going to eat? Let's order before the 1st quarter ends.  ",
        "I'll get the order since I was late.  ",
        "Thanks homie  ",
        "I already added what I want. Here add what you want to the cart.  ",
        "You're getting the  ",
        "Looks like you got another text from shorty  ",
        "Yoo!, Why did you open that!?  ",
        "Damn, is this the one you saw today? Daaamn! Why you come here, you should still be out there with her!  ",
        "Her knees are too long. I dont fucks with it.  ",
        "…Dude, really? What about this other one here?  ",
        "She slurps tea like a puppy. Its obnoxious.  ",
        "Wow, what's wrong with the one you saw yesterday?  ",
        "Her fingernails looks like pennies  ",
        "Bruh, you're buggin.  ",
        "Why should I settle when there are more options out there?  ",
        "Because you aint getting any younger! Who has time to be out in these streets wasting energy checking every single option? You just find a good one and you hold each other down. Simple  ",
        "Nah I aint trying to get with the wrong one and it just be drama?  ",
        "Then the problem aint them, its you!  ",
        "Maybe, but Im fin to keep my options open until the right one comes  ",
        "See, you’re doing it wrong. You make yourself right first. Then the right ones are easy to find. You her stressin over penny fingers and long knees, you gon starve waiting forever.  ",
        "Yeah we starving already. Half time is already over and yall still talking shit. We ordering or what?  ",
        "Let me stop asking questions before I get more confused. What are you going to order? If you’re as picky with this order we’re gonna starve like you!  ",

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
                PlayRandomSong();
                textboxText.gameObject.SetActive(true);
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
