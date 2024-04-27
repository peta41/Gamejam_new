using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour 
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 200f;

    void Start()
    {
        Cursor.visible = true;
    }
    void Update()
    {
        // Movement logic remains the same
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            float moveX = Input.GetAxisRaw("Horizontal");
            float moveZ = Input.GetAxisRaw("Vertical");

            Vector3 moveDirection = new Vector3(moveX, 0, moveZ).normalized;
            transform.position += moveDirection * moveSpeed * Time.deltaTime;
        }

        // Raycast to get the cursor's position in the world
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            // Calculate the direction from the player to the cursor
            Vector3 targetDirection = hit.point - transform.position;
            targetDirection.y = 0; // Ignore vertical movement

            // Rotate the player to face the cursor
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);

            // Add a 90-degree rotation around the Y axis
            Quaternion additionalRotation = Quaternion.Euler(0, 90, 0); // Rotate 90 degrees to the left
            targetRotation *= additionalRotation; // Apply the additional rotation

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }
    }
}