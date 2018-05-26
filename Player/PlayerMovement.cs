using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, IMoveable
{
    public float movementSpeed;
    public float jumpStrength;

    private float currentMovementSpeed;

    public List<string> actionQueue = new List<string>(); //holds a list of player actions in a queue to handle multiple inputs and act on the latest
    public List<MovementTriggerCheck> colliderChecks = new List<MovementTriggerCheck>();

    [SerializeField] private SpriteRenderer hitboxImage;
    [SerializeField] private Sprite[] playerSprites = new Sprite[5];

    private SpriteRenderer playerSpriteRenderer;

    private int     actionCount;

    private Vector2 horizontalVector,
                    processedHorizontalVector,
                    verticalVector,
                    processedVerticalVector;

    private bool    movingLeft,
                    movingRight,
                    movingUp,
                    movingDown,
                    idle,
                    jump = false;

    public CcelerationCurves horizontalCcelerationCurves, verticalCcelerationCurves;

    //Methods

    //MonoBehaviour methods 
    void Start()
    {
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
        actionQueue.Add("placeholder");
    }
    void Update()
    {

    }
    void LateUpdate()
    {
        ProcessMovementSpeed();

        Bounds();
    }

    //Input behaviour stuff
    void IMoveable.MoveLeft(bool keystate)
    {
        if (movingLeft == false && keystate == true) //getkeyUp
        {
            AddActionToActionQueue("left");
            horizontalCcelerationCurves.Reset();
        }
        else if (movingLeft == true && keystate == false) //getkeyDown
        {
            RemoveActionFromActionQueue("left");
        }

        if (GetHorizonatalPriority() == "left")
        {
            MoveLeft();
        }
        movingLeft = keystate;
    }
    void IMoveable.MoveRight(bool keystate)
    {
        if (movingRight == false && keystate == true) //getkeyUp
        {

            AddActionToActionQueue("right");
            horizontalCcelerationCurves.Reset();
        }
        else if (movingRight == true && keystate == false) //getkeyDown
        {
            RemoveActionFromActionQueue("right");
        }

        if (GetHorizonatalPriority() == "right")
        {
            MoveRight();
        }
        movingRight = keystate;
    }
    void IMoveable.MoveUp(bool keystate)
    {
        if (movingUp == false && keystate == true) //getkeyUp
        {
            AddActionToActionQueue("up");
            verticalCcelerationCurves.Reset();
        }
        else if (movingUp == true && keystate == false) //getkeyDown
        {
            RemoveActionFromActionQueue("up");
        }

        if (GetVerticalPriority() == "up")
        {
            MoveUp();
        }
        movingUp = keystate;
    }
    void IMoveable.MoveDown(bool keystate)
    {
        if (movingDown == false && keystate == true) //getkeyUp
        {
            AddActionToActionQueue("down");
            verticalCcelerationCurves.Reset();
        }
        else if (movingDown == true && keystate == false) //getkeyDown
        {
            RemoveActionFromActionQueue("down");
        }

        if (GetVerticalPriority() == "down")
        {
            MoveDown();
        }
        movingDown = keystate;
    }
    void IMoveable.Jump(bool keystate)
    {
        if (jump == false && keystate == true)
        {
            AddActionToActionQueue("jump");
        }
        else if (jump == true && keystate == false)
        {
            RemoveActionFromActionQueue("jump");
        }

        if (actionQueue[actionCount] == "jump")
        {
            Jump();
        }
        jump = keystate;
    }

    void MoveRight()
    {
        if (!CollidingRight())
            horizontalVector = Vector2.right;
    }
    void MoveLeft()
    {
        if (!CollidingLeft())
            horizontalVector = Vector2.left;
    }
    void MoveUp()
    {
        if (!CollidingUp())
            verticalVector = Vector2.up;

    }
    void MoveDown()
    {
        if (!CollidingUp())
            verticalVector = Vector2.down;
    }

    void Jump()
    {

    }

    //Collider stuff
    bool CollidingLeft()
    {
        return colliderChecks[0].IsColliding();
    }
    bool CollidingRight()
    {
        return colliderChecks[1].IsColliding();
    }
    bool CollidingUp()
    {
        return colliderChecks[2].IsColliding();
    }
    bool CollidingDown()
    {
        return colliderChecks[3].IsColliding();
    }
    //Movement stuff
    void ProcessMovementSpeed()
    {

        if(movingLeft || movingRight) // player is moving either left or right
        {
            horizontalCcelerationCurves.SetAccelerationBool(true);
            transform.Translate(horizontalVector * movementSpeed * Time.deltaTime * horizontalCcelerationCurves.GetCCelerationSpeed());
        }
        else
        {
            horizontalCcelerationCurves.SetAccelerationBool(false);
            transform.Translate(horizontalVector * movementSpeed * Time.deltaTime * horizontalCcelerationCurves.GetCCelerationSpeed());
            //deccelerate horizontaly
        }

        if(movingUp || movingDown)
        {
            verticalCcelerationCurves.SetAccelerationBool(true);
            transform.Translate(verticalVector * movementSpeed * Time.deltaTime * verticalCcelerationCurves.GetCCelerationSpeed());
        }
        else
        {
            verticalCcelerationCurves.SetAccelerationBool(false);
            transform.Translate(verticalVector * movementSpeed * Time.deltaTime * verticalCcelerationCurves.GetCCelerationSpeed());
            //deccelerate vertically
        }

        if (movingUp == false && movingDown == false && movingLeft == false && movingRight == false)
        {
            idle = true;
        }
        else
        {
            idle = false;
        }

        //transform.Translate(horizontalVector * movementSpeed * Time.deltaTime * horizontalCcelerationCurves.GetCCelerationSpeed());
        //horizontalVector = Vector3.zero;
        //verticalVector = Vector3.zero;
    }

    //ActionQueue stuff
    void RemoveActionFromActionQueue(string actionName)
    {
        actionCount = actionQueue.Count;
        for (int i = actionCount - 1; i > 0; i--)
        {
            if (actionQueue[i] == actionName)
            {
                actionQueue.RemoveAt(i);
            }
        }
        actionCount = actionQueue.Count - 1;
    }
    void AddActionToActionQueue(string actionName)
    {
        actionQueue.Add(actionName);
        actionCount = actionQueue.Count - 1;
    }
    string GetHorizonatalPriority()
    {
        for (int i = actionCount; i > 0; i--)
        {
            if(actionQueue[i] == "left" || actionQueue[i] == "right")
            {
                return actionQueue[i];
            }
        }
        return null;
    }
    string GetVerticalPriority()
    {
        for (int i = actionCount; i > 0; i--)
        {
            if (actionQueue[i] == "up" || actionQueue[i] == "down")
            {
                return actionQueue[i];
            }
        }
        return null;
    }

    //PlayerScreenBounds
    void Bounds()
    {
        var dist = (transform.position - Camera.main.transform.position).z;

        var leftBorder = Camera.main.ViewportToWorldPoint(
          new Vector3(0, 0, dist)
        ).x;

        var rightBorder = Camera.main.ViewportToWorldPoint(
          new Vector3(1, 0, dist)
        ).x;

        var topBorder = Camera.main.ViewportToWorldPoint(
          new Vector3(0, 0, dist)
        ).y;

        var bottomBorder = Camera.main.ViewportToWorldPoint(
          new Vector3(0, 1, dist)
        ).y;

        transform.position = new Vector3(
          Mathf.Clamp(transform.position.x, leftBorder, rightBorder),
          Mathf.Clamp(transform.position.y, topBorder, bottomBorder),
          transform.position.z
        );
    }
}
/*
    // All movement options
    private void Move()
    {
        if (moveup == true)
        {
            playerSpriteRenderer.sprite = playerSprites[0]; // upsprite
            transform.Translate(Vector2.up * Time.deltaTime * speed);
        }

        else if (movedown == true)
        {
            playerSpriteRenderer.sprite = playerSprites[1]; // downsprite
            transform.Translate(Vector2.down * Time.deltaTime * speed);

        }

        else if (moveleft == true)
        {
            playerSpriteRenderer.sprite = playerSprites[2]; // leftsprite
            transform.Translate(Vector2.left * Time.deltaTime * speed);

        }

        else if (moveright == true)
        {
            playerSpriteRenderer.sprite = playerSprites[3]; // rightsprite
            transform.Translate(Vector2.right * Time.deltaTime * speed);

        }
        else
        {
            playerSpriteRenderer.sprite = playerSprites[4]; // idlesprite
        }
    }

    //Sets boundaries
    void Bounds()
    {
        var dist = (transform.position - Camera.main.transform.position).z;

        var leftBorder = Camera.main.ViewportToWorldPoint(
          new Vector3(0, 0, dist)
        ).x;

        var rightBorder = Camera.main.ViewportToWorldPoint(
          new Vector3(1, 0, dist)
        ).x;

        var topBorder = Camera.main.ViewportToWorldPoint(
          new Vector3(0, 0, dist)
        ).y;

        var bottomBorder = Camera.main.ViewportToWorldPoint(
          new Vector3(0, 1, dist)
        ).y;

        transform.position = new Vector3(
          Mathf.Clamp(transform.position.x, leftBorder, rightBorder),
          Mathf.Clamp(transform.position.y, topBorder, bottomBorder),
          transform.position.z
        );
    }

    //Set movement booleans true
    public void MoveUp()
    {
        moveup = true;
        movedown = false;
    }

    public void MoveDown()
    {
        movedown = true;
        moveup = false;
    }

    public void MoveLeft()
    {
        moveleft = true;
        moveright = false;
    }

    public void MoveRight()
    {
        moveright = true;
        moveleft = false;
    }

    // Set movement booleans false
    public void StopMoveUp()
    {
        moveup = false;
    }

    public void StopMoveDown()
    {
        movedown = false;
    }

    public void StopMoveLeft()
    {
        moveleft = false;
    }

    public void StopMoveRight()
    {
        moveright = false;
    }

    // Set extra movement effect to half speed
    public void HalfSpeed()
    {
        hitboxImage.gameObject.SetActive(true);
        speed = speed * 0.5f;
    }

    // Set extra movement effect to normal speed 
    public void NormalSpeed()
    {
        hitboxImage.gameObject.SetActive(false);
        speed = speed * 2;
    }

}
*/
