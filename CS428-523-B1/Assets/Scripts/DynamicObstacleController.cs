using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicObstacleController : MonoBehaviour
{
    public GameObject waypoints;
    List<Transform> targets;
    private Rigidbody rb;
    private int currentTargetId;
    public float stepSize = 0.1f;
    private float positionScale = 1.0f;
    private float velocityScale = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        targets = new List<Transform>();
        // load the waypoints, set the order
        foreach (Transform child in waypoints.transform)
        {
            //Debug.Log("child: " + child.name);
            targets.Add(child);
        }
        rb = GetComponent<Rigidbody>();
        currentTargetId = 0;  // currently go to the first target
    }

    // Update is called once per frame
    void Update()
    {
        // move the obstacle according to the waypoint
        //Debug.Log("target: " + targets[currentTargetId].position.ToString());

        Vector3 diff = targets[currentTargetId].position - this.transform.position;
        float dist = Vector3.Distance(targets[currentTargetId].position, this.transform.position);
        //diff = diff / dist;  // normalize

        // apply ds in the direction
        //rb.AddForce(ComputeForce(diff));

        //if (dist < 1.0f)
        //{
        //    currentTargetId = (currentTargetId + 1) % targets.Count;
        //}

        if (dist > stepSize)
        {
            Vector3 step = diff / dist * stepSize;
            //Debug.Log("step: " + step.ToString());

            this.transform.position = this.transform.position + step;
        }
        else
        {
            Vector3 step = diff;
            this.transform.position = this.transform.position + step;
            currentTargetId = (currentTargetId + 1) % (targets.Count);
        }

    }
    Vector3 ComputeForce(Vector3 diff)
    {
        // given positional difference and current velocity of the rigid body, obtain the force
        Vector3 velocity = rb.velocity;
        Vector3 force;
        force.x = diff.x * positionScale - velocity.x * velocityScale;
        force.y = diff.y * positionScale - velocity.y * velocityScale;
        force.z = diff.z * positionScale - velocity.z * velocityScale;
        //Debug.Log("Force: " + (force.ToString()));
        return force;
    }
}
