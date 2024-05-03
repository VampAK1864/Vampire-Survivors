using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowWeapon : MonoBehaviour
{
    public float throwPower; // The power of the throw. GK
    public Rigidbody2D theRB; // The rigidbody of the weapon. GK
    public float rotateSpeed; // The speed of rotation. GK
    // Start is called before the first frame update
    void Start()
    {
        theRB.velocity = new Vector2(Random.Range(-throwPower,throwPower), throwPower); // Set the velocity of the rigidbody. GK
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(0f,0f,transform.rotation.eulerAngles.z + (rotateSpeed * 360f * Time.deltaTime * Mathf.Sign(theRB.velocity.x))); // Rotate the weapon. GK
    }
}
