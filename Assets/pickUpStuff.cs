using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUpStuff : MonoBehaviour
{
    public LayerMask pickUpLayer;
    public Camera player;
    public Transform holdpos;
    public float pickUpRange;
    private Rigidbody currentObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currentObject)
            {
                currentObject.useGravity = true;
                gameObject.GetComponent<Animator>().enabled = false; // should pause the animation when an object is picked up by player
                currentObject = null;
                return;
            }

            Ray CameraRay = player.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            if(Physics.Raycast(CameraRay, out RaycastHit HitInfo, pickUpRange, pickUpLayer))
            {
                currentObject = HitInfo.rigidbody;
                currentObject.useGravity = false;
                gameObject.GetComponent<Animator>().enabled = true; // should start the animation when SPACE is pressed again to put down an object
            }
        }
    }

    private void FixedUpdate()
    {
        if (currentObject)
        {
            Vector3 directionToPoint = holdpos.position - currentObject.position;
            float distanceToPoint = directionToPoint.magnitude;

            currentObject.velocity = directionToPoint * 50f * distanceToPoint;
        }
    }
}
