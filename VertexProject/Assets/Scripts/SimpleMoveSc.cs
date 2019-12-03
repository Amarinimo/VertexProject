using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMoveSc : MonoBehaviour
{
    public KeyCode up, down, left, right;
    public int horizontalAx, verticalAx;
    public float speed = 5f;
    public float rotationSpeed = 0.2f;
    public float inputDelay = 0.2f;

    public Vector2 facingDirection = new Vector2(0f, 1f);

    private Rigidbody rb;
   
    private Vector2 prevInput;
    private Vector2 arrowInput;

    private float targetRotationY;
    private float previousRotationY;
    private float rotationTimer;
    private float inputDelayTimer;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        prevInput = Vector2.zero;
        rotationTimer = 0f;
        inputDelayTimer = 0f;
    }
    
  
    void Update()
    {

        MyGetInput();
        if(inputDelayTimer==0f &&(horizontalAx!=prevInput.x || verticalAx!=prevInput.y))
        {
            inputDelayTimer = inputDelay;
            arrowInput = new Vector2(horizontalAx * (1 - (1 - Mathf.Sqrt(2) / 2) * Mathf.Abs(verticalAx)),
                                 verticalAx * (1 - (1 - Mathf.Sqrt(2) / 2) * Mathf.Abs(horizontalAx)));
            Debug.Log("H= " + horizontalAx + "  W=" + verticalAx + " AH=" + arrowInput.x + " AW=" + arrowInput.y);

            if (horizontalAx != 0f || verticalAx != 0f)
            {
                previousRotationY = transform.eulerAngles.y;
                targetRotationY = Mathf.Atan2(horizontalAx, verticalAx) * Mathf.Rad2Deg;
                rotationTimer = 0f;
                facingDirection = new Vector2(horizontalAx,verticalAx);
            }
            prevInput = new Vector2(horizontalAx, verticalAx);
            
        }
        rotationTimer += Time.deltaTime*rotationSpeed;
        if(inputDelayTimer<=0f)
        {
            inputDelayTimer = 0f;
        }
        else
        {
            inputDelayTimer -= Time.deltaTime;
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector3(arrowInput.x*speed, rb.velocity.y, arrowInput.y*speed);
        transform.eulerAngles = new Vector3(0, Mathf.LerpAngle(previousRotationY,targetRotationY,rotationTimer/**Mathf.Abs((targetRotationY-previousRotationY)/180f)*/), 0);
    }
    private void MyGetInput()
    {
        if (Input.GetKey(up))
        {
            verticalAx = 1;
        }
        else if (Input.GetKey(down))
        {
            verticalAx = -1;
        }
        else
        {
            verticalAx = 0;
        }
        
        if (Input.GetKey(left))
        {
            horizontalAx = -1;
        }
        else if (Input.GetKey(right))
        {
            horizontalAx = 1;
        }
        else
        {
            horizontalAx = 0;
        }
    }
}
