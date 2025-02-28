using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class playerDetection3 : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] songs = new AudioClip[5];
    public TextMeshProUGUI textboxText;
    bool isPlayerInRange = false;
    private int currentDialogueIndex = 0;
    private string[] dialogue3 = {
        "Esther: What a day!  ",
        "Nathan: Did you have fun at grandma’s birthday party?  ",
        "Esther: It was a lot of work, but I think everyone had a good time!  ",
        "Nathan: Yeah, Uncle Aaron and Uncle Greg seemed happy.  ",
        "Esther: Yeah, and Uncle Greg didn’t cry this time.  ",
        "Nathan: Heh. Yeah he always gets emotional. Was he always like that?  ",
        "Esther: Hmm. Maybe not. Maybe after having Jalen and Tamara he started to soften up in that way.  ",
        "Nathan: Were you and him close growing up?  ",
        "Esther: I mean that’s my brother. What do you mean close?  ",
        "Nathan: Like, did yall talk about stuff? Did yall trust each other?  ",
        "Esther: That’s my brother. I guess we didn’t really talk much. But we’re just family.  ",
        "Nathan: Hmm. Were you close with grandma?  ",
        "Esther: If you mean close in the same way, it was a different time. Grandma took care of us, . But talking about yourself wasn’t really a part of that.  ",
        "Nathan: So how did you know she loved you.  ",
        "Esther: She took care of us. she made sure we had everything we needed. Clothes, food a place to sleep. Examples of how to be, how to treat other people. She provided so much for us. Doesn’t that mean she loves us?  ",
        "Nathan: Yeah, I guess it does. It’s probably clear to her in her mind. But how can a child understand that those actions mean love?  ",
        "Esther: …it’s not something we really thought much about. We just took things one day at a time. Even if you take time to explain how each of those actions were done with our best interests at heart, and how all the sacrifice and long hours at work, and discipline to work and earn and to provide were all just for us…you think we were sitting still for that talk?! You think your bad-mind Uncle Aaron was sitting still for any of that? The stories I could tell about your uncles when they were boys.  ",
        "Nathan: …that’s a good point  ",
        "Esther: You know your Uncle Aaron took scissors across the street and went into the neighbor’s backyard and cut this little girl’s hair?  ",
        "Nathan: Heh, yeah I’ve heard that one already mom. He was the wild one right?  ",
        "Esther: Wild doesn’t even tell half the story. He was so out of order… Funny how people change. Now he’s the most peaceful and disciplined in the whole family.  ",
        "Nathan: You’re probably right that kids won’t understand sacrifice, but maybe at that stage, they don’t really need to.  ",
        "Esther: What do you mean?  ",
        "Nathan: Aren’t there more ways to show love than to explain the sacrifices you're making?  ",
        "Esther: I suppose so. How do you show love?  ",
        "Nathan: I can use words, or gifts or hugs, or just be there at the right times. There are a bunch of ways. But also the way I show love doesn’t always match the way I feel loved. How do you feel love, mom?  ",
        "Esther: What do you mean?  ",
        "Nathan: I could cook for you, or help you clean up the dishes or buy you some nice flowers or write you a nice letter. Or watch TV with you or give you a big hug. But what makes you feel loved the most?  ",
        "Esther: Hmm, it’s not something we really thought about much.  ",
        "Nathan: That makes sense. I guess since grandma didn’t really either.  ",
        "Esther: It didn’t seem like she did..Well anyways, I love you, Nathan.  ",
        "Nathan: Now I know mom. I love you too.  ",

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
            if (currentDialogueIndex < dialogue3.Length)
            {
                textboxText.text = dialogue3[currentDialogueIndex];
            }
      
            else if (currentDialogueIndex == dialogue3.Length)
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
            textboxText.text = dialogue3[currentDialogueIndex];
        }
    }
    void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
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
