
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float forwardForce = 600f;
    public float backForce = 520f;
    public float sideForce = 550f;
    public float jumpForce = 1000f;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello, World!"); 
    }

    // Update is called once per frame
    // when you work with physics unity likes it better if you use FixedUpdate
    void FixedUpdate()
    {
        
        if (Input.GetKey("d")) 
        { rb.AddForce(sideForce * Time.deltaTime, 0, 0); }
        if (Input.GetKey("a"))
        { rb.AddForce(sideForce * -1 * Time.deltaTime, 0, 0); }
        if (Input.GetKey("w"))
        { rb.AddForce(0, 0, forwardForce * Time.deltaTime); }
        if (Input.GetKey("s"))
        { rb.AddForce(0, 0, backForce * Time.deltaTime * -1); }
        if (Input.GetKey("space"))
        { rb.AddForce(0, jumpForce*Time.deltaTime, 0); }
    }
}

