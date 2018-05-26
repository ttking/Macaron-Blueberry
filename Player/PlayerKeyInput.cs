using UnityEngine;

public class PlayerKeyInput : MonoBehaviour {
    public IMoveable moveable;

    private PlayerInputManager inputManager;
	// Use this for initialization
	void Start () {
        moveable = GetComponent<PlayerMovement>();
        inputManager = GetComponent<PlayerInputManager>();
	}
	
	// Update is called once per frame
	void Update () {
        moveable.MoveLeft(Input.GetKey(inputManager.left));
        moveable.MoveRight(Input.GetKey(inputManager.right));
        moveable.MoveUp(Input.GetKey(inputManager.up));
        moveable.MoveDown(Input.GetKey(inputManager.down));
    }
}
