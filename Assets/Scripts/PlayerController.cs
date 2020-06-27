using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject cam;

    float horizontalInput;
    float verticalInput;

    public float moveSpeed = 5f;
    //public Rigidbody rb;
    public CharacterController cc;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("LeftTrackpadHorizontal");
        verticalInput = Input.GetAxis("LeftTrackpadVertical");
    }

    void FixedUpdate()
    {
        Quaternion rot = Quaternion.Euler(0, cam.transform.rotation.eulerAngles.y, 0);
        Vector3 move = rot * new Vector3(horizontalInput, 0, verticalInput);
        //transform.Translate(move * moveSpeed * Time.deltaTime);
        //rb.AddForce(move * moveSpeed * Time.deltaTime, ForceMode.Impulse);
        cc.Move(move * moveSpeed * Time.deltaTime);
    }
}
