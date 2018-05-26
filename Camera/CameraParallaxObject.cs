using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraParallaxObject : MonoBehaviour {
    [SerializeField]private Camera mainCamera;

    Vector3 cameraStartingPosition;
    Vector3 startingPosition;
    float parallaxStrength;
    [Range(0, 100)]
    public int objectDistance = 0;

    Vector3 lastPosition;

    [SerializeField]private CameraParallaxController parallaxController;
	// Use this for initialization
	void Start () {
        if(objectDistance > 0)
        {
            parallaxController.AddParallaxObjectToList(this);
            parallaxStrength = -parallaxController.GetParallaxStrength(objectDistance / 100f);
            if (!GetComponent<SpriteRenderer>())
            {

            }
            else
            {
                GetComponent<SpriteRenderer>().sortingOrder = -objectDistance * 2;
            }
            startingPosition = transform.position;

            if(!mainCamera)
            mainCamera = Camera.main;
        }
        else
        {
            this.enabled = false;
        }
    }

    public void ParallaxScroll()
    {
            Vector3 difference = (startingPosition - new Vector3(mainCamera.transform.position.x, mainCamera.transform.position.y, 0)); //subtraction cancels out z axis, reduces extra vector calculations;
            transform.position = startingPosition + (difference * parallaxStrength);
    }
    private void OnBecameVisible()
    {
        //parallaxController.AddParallaxObjectToList(this);
    }

    private void OnBecameInvisible()
    {
        //parallaxController.RemoveParallaxObjectFromList(this);
    }
}
