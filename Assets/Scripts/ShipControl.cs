using UnityEngine;
using SingletonT;

public class ShipControl : SingletonT<ShipControl>
{
    public Rigidbody2D shipRig;
    public float force;
    public float turnForce;

    float axelerometrX;
    float axelerometrY;

    [Header("For debug")]
    public float forceInput;
    public float turnInput;

  
    private MobileController mobControll;

   

    private void Start()
    {
        mobControll = FindObjectOfType<MobileController>();
    }


    void Update()
    {
       

        // forceInput = Input.GetAxis("Vertical");
        // turnInput = Input.GetAxis("Horizontal");

        forceInput = mobControll.Vertical();
        turnInput = mobControll.Horizontal();



        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("Play Clip ");
            AudioManager.Instance.PlayClip("Engine");
        }

        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            Debug.Log("Play Clip ");
            AudioManager.Instance.StopClip("Engine");
        }


        transform.Rotate(Vector3.forward * turnInput * -turnForce * Time.deltaTime);

    }



    private void FixedUpdate()
    {
        shipRig.AddRelativeForce(Vector2.up * force * forceInput);
    }


}
