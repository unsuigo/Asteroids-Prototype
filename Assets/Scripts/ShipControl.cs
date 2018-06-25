using UnityEngine;

public class ShipControl : MonoBehaviour
{
    public Rigidbody2D shipRig;
    public float force;
    public float turnForce;

    [Header("For debug")]
    public float forceInput;
    public float turnInput;

    //Singleton will avoid second ship 
    public static ShipControl instance;

    //Singleton init
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
    }


    void Update()
    {

        forceInput = Input.GetAxis("Vertical");
        turnInput = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("Play Clip ");
            FindObjectOfType<AudioManager>().PlayClip("Engine");
        }

        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            Debug.Log("Play Clip ");
            FindObjectOfType<AudioManager>().StopClip("Engine");
        }


        transform.Rotate(Vector3.forward * turnInput * -turnForce * Time.deltaTime);

    }



    private void FixedUpdate()
    {
        shipRig.AddRelativeForce(Vector2.up * force * forceInput);
    }


}
