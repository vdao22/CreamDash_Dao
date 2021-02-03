using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotSpikes : MonoBehaviour
{
    private PlayerControl player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
    }

    // When player collides with traps enemies, player loses 1 HP and gets knockup
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.Damage(1);

            StartCoroutine(player.Knockup(0.02f, -250, player.transform.position));
        }
    }
}
