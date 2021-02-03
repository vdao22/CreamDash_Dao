using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadStomp : MonoBehaviour
{
    public int damageAmount;
    [SerializeField] GameObject explosion;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Instantiate(explosion, transform.position, explosion.transform.rotation);
            SoundManagerScript.PlaySound("enemydeath");
            collision.GetComponent<EnemyHealth>().doDamage(damageAmount);
        }
    }
}
