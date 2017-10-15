using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingBallController : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
        }
      
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            StartCoroutine(Delayed());
        }
    }
    IEnumerator Delayed()
    {
        yield return new WaitForSeconds(6f);
        gameObject.SetActive(false);
    }
}
