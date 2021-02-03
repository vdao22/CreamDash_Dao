using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour
{
    public Sprite[] HeartSprites;
    public Image HeartUI;
    private PlayerControl player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
    }

    void Update()
    {
        HeartUI.sprite = HeartSprites[player.currentHealth];
    }
}
