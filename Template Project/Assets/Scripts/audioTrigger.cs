using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioTrigger : MonoBehaviour
{
    public AudioSource audioSource;
    public bool isPlaying = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
/*
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !isPlaying)
        {
            int randomIndex = Random.Range(0, audioSource.clip.length);
            audioSource.time = randomIndex;
            audioSource.Play();
            isPlaying = true;
        }
    }
*/
}
