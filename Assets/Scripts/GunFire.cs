
using UnityEngine;

public class GunFire : MonoBehaviour {

    public GameObject bulletPrefab;
    public float bulletForce;
    public float bulletTime;


    void Update () {

		if(Input.GetButtonDown("Fire1"))
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up* bulletForce);
            Destroy(bullet, bulletTime);
        }
	}
}
