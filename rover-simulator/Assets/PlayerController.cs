using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float ForwardForce = 2000.0f;
    public float sidewaysForce = 500.0f;

    public int numEnemiesHit = 0;

    public CanvasController canvasController;

    void FixedUpdate()
    {
        rb.AddForce(0, 0, ForwardForce * Time.deltaTime);

        float horiz = Input.GetAxis("Horizontal");

        // if(Input.GetKey("d")) {
            rb.AddForce(horiz * sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        // } else if (Input.GetKey("a")) {
            // rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        // } else {
            // rb.velocity = new Vector3(0, rb.velocity.y, rb.velocity.z);
        // }

        if(horiz == 0) {
            rb.velocity = new Vector3(0, rb.velocity.y, rb.velocity.z);
        }
    }

    void OnTriggerEnter(Collider collider) {
        if(collider.tag == "Enemy") {
            numEnemiesHit++;
            canvasController.StartFlash(0.1f, 0.6f);
        }
    }
}
