using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBehavior : MonoBehaviour {


    public float maxForce;
    public float maxTorque;
    public Rigidbody2D asteroidRig;
    //public int points;
    

    public GameObject[] asteroidChildren;

   // private float screenY;
   // private float screenX;
    GameObject manager;

    void Start () {

        RandomForceAndTorque();
        manager = GameObject.Find("GameManager");
    }

  // public void OnCollisionEnter2D(Collision2D collision)
  // {
  //     if(collision.gameObject.CompareTag("Bullet") )
  //     {
  //         manager.SendMessage("OnScoreAdd", points);
  //        // manager.SendMessage("OnExplode", transform);
  //        
  //         Destroy(collision.gameObject);
  //
  //         InstantiateChildren();
  //
  //         Destroy(gameObject);
  //     }
  //
  //   if( collision.gameObject.CompareTag("Ship"))
  //     {
  //         
  //         manager.SendMessage("OnExplode", transform);
  //         Destroy(collision.gameObject);
  //         Destroy(gameObject);
  //     }
  // }


    void RandomForceAndTorque()
    {
        Vector2 randomForce = new Vector2(Random.Range(-maxForce, maxForce), Random.Range(-maxForce, maxForce));
        float randomTorque = (Random.Range(-maxTorque, maxTorque));
        asteroidRig.AddForce(randomForce);
        asteroidRig.AddTorque(randomTorque);
    }

 //   void InstantiateChildren()
 //   {
 //       foreach (GameObject child in asteroidChildren)
 //       {
 //           Instantiate(child, transform.position, transform.rotation);
 //       }
 //   }

    

}
