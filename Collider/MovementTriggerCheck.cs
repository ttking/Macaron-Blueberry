using UnityEngine;

public class MovementTriggerCheck : MonoBehaviour {
    public bool isColliding;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Blockable")
            isColliding = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Blockable")
            isColliding = false;
    }

    public bool IsColliding()
    {
        return isColliding;
    }
}
