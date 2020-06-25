using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject cam;

    float horizontalInput;
    float verticalInput;

    public float moveSpeed = 5f;
    public CharacterController cc;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("HorizontalK");
        verticalInput = Input.GetAxis("VerticalK");
    }

    void FixedUpdate()
    {
        Quaternion rot = Quaternion.Euler(0, cam.transform.rotation.eulerAngles.y, 0);
        Vector3 move = rot * new Vector3(horizontalInput, 0, verticalInput);
        cc.Move(move * moveSpeed * Time.deltaTime);
    }
}
