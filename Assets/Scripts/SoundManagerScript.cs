using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip enemyDeathSound, jumpSound, takeDMGSound;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        enemyDeathSound = Resources.Load<AudioClip>("enemydeath");
        jumpSound = Resources.Load<AudioClip>("jump");
        takeDMGSound = Resources.Load<AudioClip>("takedmg");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void PlaySound (string clip)
    {
        switch (clip)
        {
            case "enemydeath":
                audioSrc.PlayOneShot(enemyDeathSound);
                break;
            case "jump":
                audioSrc.PlayOneShot(jumpSound);
                break;
            case "takedmg":
                audioSrc.PlayOneShot(takeDMGSound);
                break;
        }
    }
}
