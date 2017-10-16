using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingBallController : MonoBehaviour {
    public GameObject effect;
    public GameObject player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject newEffect = (GameObject)Instantiate(effect,player.transform .position,effect.transform.rotation);
            newEffect.transform.parent = player.transform;
            gameObject.SetActive(false);
            Destroy(newEffect, 1.0f);
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
