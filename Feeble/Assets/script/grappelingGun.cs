using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grappelingGun : MonoBehaviour
{
    private LineRenderer lr;
    private Vector3 grapplePoint;
    public LayerMask whatIsGrappleable;
    public Transform gunTip, camera, player;
    private float maxDistance = 100f;
    [SerializeField]
    private SpringJoint joint;
    private float overTime = 1.5f;
    private bool grappling;
    private bool isDrawing;
    void Awake()
    {
        lr = GetComponent<LineRenderer>();
        grappling = false;
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.G))
        {
            StartGrapple();
        }
        if (Input.GetKeyUp(KeyCode.H))
        {
            StopGrapple();
        }
    }

    //Called after Update
    void LateUpdate()
    {
        //If not grappling, don't draw rope
        if (joint && !isDrawing)
            StartCoroutine(DrawRope());
    }

    /// <summary>
    /// Call whenever we want to start a grapple
    /// </summary>
    void StartGrapple()
    {
        RaycastHit hit;
        if (Physics.Raycast(camera.position, camera.forward, out hit, maxDistance, whatIsGrappleable))
        {
            grapplePoint = hit.point;
            joint = player.gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = grapplePoint;

            float distanceFromPoint = Vector3.Distance(player.position, grapplePoint);

            //The distance grapple will try to keep from grapple point. 
            joint.maxDistance = distanceFromPoint * 0.8f;
            joint.minDistance = distanceFromPoint * 0.25f;

            //Adjust these values to fit your game.
            joint.spring = 4.5f;
            joint.damper = 7f;
            joint.massScale = 4.5f;

            lr.positionCount = 2;
            currentGrapplePosition = gunTip.position;
            grappling = true;
        }
    }


    /// <summary>
    /// Call whenever we want to stop a grapple
    /// </summary>
    void StopGrapple()
    {
        lr.positionCount = 0;
        grappling = false;
        isDrawing = false;

        Destroy(joint);
    }

    private Vector3 currentGrapplePosition;

    IEnumerator DrawRope()
    {
        isDrawing = true;
        float currentTime = Time.time;

        float maxDistance = joint.maxDistance;
        float lowestMaxDistance = joint.maxDistance / 2;
        while (Time.time < (currentTime + overTime))
        {
            if (joint)
                joint.maxDistance = Mathf.Lerp(maxDistance, lowestMaxDistance, (Time.time - currentTime) / overTime);

            yield return null;
        }
    }

    public bool IsGrappling()
    {
        return joint != null;
    }

    public Vector3 GetGrapplePoint()
    {
        return grapplePoint;
    }
}
