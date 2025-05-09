using UnityEngine;

public class ClawControls : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float dropSpeed = 2f;
    public float dropDistance = 3f;
    public float minX = -5f;
    public float maxX = 5f;

    private bool isDropping = false;
    private Vector3 startPosition;
    private Coroutine dropRoutine; 
    private GameObject grabbedObject = null;
    private bool isHoldingObject = false;


    private int moveDirection = 0; // -1 = left, 1 = right, 0 = none
    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        HandleHorizontalMovement();
        HandleDropInput();
    }

    void HandleHorizontalMovement()
    {
        if (isDropping) return;

        //float moveInput = Input.GetAxis("Horizontal");
        Vector3 newPosition = transform.position + new Vector3(moveDirection * moveSpeed * Time.deltaTime, 0, 0);
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
        transform.position = newPosition;
    }

    public void OnLeftButtonDown() { moveDirection = -1; Debug.Log("Left down"); }
    public void OnRightButtonDown() { moveDirection = 1; Debug.Log("Right down"); }
    public void OnButtonUp() { moveDirection = 0; } // Call this on Button Up (PointerUp) event

    public void OnDropButtonDown()
    {
        if (!isDropping && !isHoldingObject)
        {
            dropRoutine = StartCoroutine(DropClaw());
        }
        else if (!isDropping && isHoldingObject)
        {
            ReleaseGrabbedObject();
        }
    }

    void HandleDropInput()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (!isDropping && !isHoldingObject)
            {
                dropRoutine = StartCoroutine(DropClaw());
            }
            else if (!isDropping && isHoldingObject)
            {
                // Drop the held object
                ReleaseGrabbedObject();
            }
        }
    }
    void ReleaseGrabbedObject()
    {
        if (grabbedObject != null)
        {
            grabbedObject.transform.SetParent(null);
            Rigidbody2D rb = grabbedObject.GetComponent<Rigidbody2D>();
            if (rb != null) rb.isKinematic = false;
            grabbedObject = null;
            isHoldingObject = false;
        }
    }



    System.Collections.IEnumerator DropClaw()
    {
        isDropping = true;
        Vector3 targetPosition = transform.position + Vector3.down * dropDistance;

        while (transform.position.y > targetPosition.y)
        {
            transform.position += Vector3.down * dropSpeed * Time.deltaTime;
            yield return null;
        }

        // If it doesn't hit anything, return after reaching bottom
        StartCoroutine(ReturnClaw());
    }

    System.Collections.IEnumerator ReturnClaw()
    {
        while (transform.position.y < startPosition.y)
        {
            transform.position += Vector3.up * dropSpeed * Time.deltaTime;
            yield return null;
        }

//        transform.position = startPosition;
        isDropping = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (isDropping && !isHoldingObject)
        {

            // Grab
            grabbedObject = other.gameObject;

            //If grabbed Object is Ball, the ball is attached to the claw. If not, don't attach.
            if (grabbedObject.tag == "Ball")
            
                grabbedObject.transform.SetParent(transform);
                Rigidbody2D rb = grabbedObject.GetComponent<Rigidbody2D>();
            

            // Optional: disable gravity so it doesn’t fall off
            if (rb != null)
                rb.isKinematic = true;

            // Return the claw
            if (dropRoutine != null)
                StopCoroutine(dropRoutine);

            StartCoroutine(ReturnClaw());
            isHoldingObject = true;
        }
    }
    


}
