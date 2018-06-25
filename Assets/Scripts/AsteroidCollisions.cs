using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidCollisions : MonoBehaviour {

    GameObject gameManager;
    public GameObject explosionFX;
    public int points;
    public GameObject[] asteroidChildren;
   

    void Start()
    {
        gameManager = GameObject.Find("GameManager");
    }



    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Bullet")
        {
            Debug.Log("Collision with " + collision.gameObject.name);
            gameManager.SendMessage("OnScoreAdd", points);
            GameObject explosion = Instantiate(explosionFX, transform.position, transform.rotation);
            Destroy(explosion, 3f);
            InstantiateChildren();
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

      //  if(collision.collider.tag == "Ship")
      //  {
      //      gameManager.SendMessage("OnMinusLife");
      //      Destroy(collision.gameObject);
      //      Destroy(gameObject);
      //  }
    }

    void InstantiateChildren()
    {
        foreach (GameObject child in asteroidChildren)
        {
            Instantiate(child, transform.position, transform.rotation);
        }
    }
}
