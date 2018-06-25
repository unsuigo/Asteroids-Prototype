using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCollisions : MonoBehaviour {

    public GameObject deathFXPrefab;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag =="Bullet"|| collision.collider.tag == "Asteroid")
        {
            Debug.Log("Collision with " + collision.gameObject.name);
            Destroy(collision.gameObject);
           GameObject deathShipFX = Instantiate(deathFXPrefab, transform.position, transform.rotation);
            ShipDead();
            Destroy(deathShipFX, 3f);
            Destroy(gameObject);
        }
    }

    void ShipDead()
    {
        FindObjectOfType<AudioManager>().StopClip("Engine");

        GameObject manager = GameObject.Find("GameManager");

        if (manager != null)
        {
           // manager.SendMessage("OnReset");
            manager.SendMessage("OnMinusLife");
        }
    }
}
