using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float movementSpeed = 7f;
    [SerializeField] float jumpStrength = 5f;
    [SerializeField] bool onGround = true; 
    [SerializeField] float rotationSpeed;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update() {
        float horizontalInput = Input.GetAxis("Horizontal"); 
        float verticalInput = Input.GetAxis("Vertical");


        Vector3 movementDirection = new Vector3(horizontalInput * movementSpeed, rb.velocity.y, verticalInput * movementSpeed);
        movementDirection.Normalize();

        transform.Translate(movementDirection * movementSpeed * Time.deltaTime, Space.World);

        //rb.velocity = new Vector3(horizontalInput * movementSpeed, rb.velocity.y, verticalInput * movementSpeed);
        //rb.velocity.Normalize();

        if (movementDirection != Vector3.zero) {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);  

        }

        //Programmed in Unity itself
        if (Input.GetButtonDown("Jump") && onGround){ 
            rb.AddForce(new Vector3(rb.velocity.x, jumpStrength, rb.velocity.z), ForceMode.Impulse);
            //rb.velocity = new Vector3(rb.velocity.x, jumpStrength, rb.velocity.z);
            onGround = false;
        }
        
        /* Hard-coded
        if (Input.GetKeyDown("space")) {
            rb.velocity = new Vector3(0, 5f, 0);
        }

        if (Input.GetKey("up")) {
            rb.velocity = new Vector3(0, 0, 5f);
        }

        if (Input.GetKey("right")) {
            rb.velocity = new Vector3(5f, 0, 0);
        }

        if (Input.GetKey("down")) {
            rb.velocity = new Vector3(0, 0, -5f);
        }

        if (Input.GetKey("left")) {
            rb.velocity = new Vector3(-5f, 0, 0);
        }
        */
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Ground"){
            onGround = true;
        }

    }
}
