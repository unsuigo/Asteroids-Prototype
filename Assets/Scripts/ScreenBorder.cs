
using UnityEngine;

public class ScreenBorder : MonoBehaviour {

    private float screenX;
    private float screenY;

    void Start()
    {
        ScreenBorderSetup();
    }

    void ScreenBorderSetup()
    {
        screenY = Camera.main.orthographicSize;
        screenX = screenY * Camera.main.aspect;
        transform.localScale = new Vector2(screenX * 2, screenY * 2);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
       // Debug.Log("Plane EXIT  " + collision.gameObject.name);
        if (collision.transform.position.y > screenY || collision.transform.position.y < -screenY)
        {
            
            collision.transform.position = new Vector2(collision.transform.position.x, -collision.transform.position.y);
        }

        if (collision.transform.position.x > screenX || collision.transform.position.x < -screenX)
        {

            collision.transform.position = new Vector2(-collision.transform.position.x, collision.transform.position.y);
        }
    }

   

}
