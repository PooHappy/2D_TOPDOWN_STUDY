using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Border" || collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
