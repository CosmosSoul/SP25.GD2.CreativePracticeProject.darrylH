using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class visitorMovementScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);
        transform.Translate(movement * Time.deltaTime * 5f);

        // Get mouse movement for rotation
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        
        // Rotate the player based on mouse X movement
        transform.Rotate(Vector3.up * mouseX * 2f);
    }
}
