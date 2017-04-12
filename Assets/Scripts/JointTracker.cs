using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Windows.Kinect;

public class JointTracker : MonoBehaviour {

    public JointType JointToUse;
    public BodySourceManager _bodyManager;
    public float scale = 8f;
    public float yOffset = -5f;
    public int BodyNumber = 0;
    public GameObject PointToward;

    private TrackerDot m_trackerDot;
    private float m_trackerStartingY;

    void Awake()
    {
        m_trackerDot = FindObjectOfType<TrackerDot>();
        m_trackerStartingY = m_trackerDot.transform.position.y;
    }

    // Get body data from the body manager and track the joint for the active body
    void Update()
    {
        if (_bodyManager == null)
        {
            return;
        }

        Body[] data = _bodyManager.GetData();
        if (data == null)
        {
            return;
        }

        // Use for testing with a single body model to make life easier
        foreach(Body body in data)
        {
            if ((body != null) && (body.IsTracked))
            {
                var pos = body.Joints[JointToUse].Position;
                //float yPosition = (pos.Y * scale) + (yOffset + (m_trackerDot.transform.position.y - m_trackerStartingY));
                Vector3 targetPosition = new Vector3(pos.X * scale, yOffset + pos.Y * scale, 0f);
                //this.transform.position = Vector3.MoveTowards(this.transform.position, targetPosition, Time.deltaTime * 10);
                this.transform.position = targetPosition;
                Quaternion rotation;
                rotation.x = body.JointOrientations[JointToUse].Orientation.X;
                rotation.y = body.JointOrientations[JointToUse].Orientation.Y;
                rotation.z = body.JointOrientations[JointToUse].Orientation.Z;
                rotation.w = body.JointOrientations[JointToUse].Orientation.W;
                Vector3 eulerRotation = rotation.eulerAngles;
                Vector3 limitedRotation = new Vector3(0f, 0f, -eulerRotation.z);
                transform.rotation = Quaternion.Euler(limitedRotation);
                //var rotation = Quaternion.LookRotation(lookPos);
                //transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
            }
        }

        //if((data.Length >= BodyNumber) && (data[BodyNumber] != null) && (data[BodyNumber].IsTracked))
        //{
        //    GetComponent<Rigidbody>().isKinematic = true;
        //    var pos = data[BodyNumber].Joints[JointToUse].Position;
        //    float yPosition = (pos.Y * scale) + (yOffset + (m_trackerDot.transform.position.y - m_trackerStartingY));
        //    Vector3 targetPosition = new Vector3(pos.X * scale, yPosition, 0f);
        //    //this.transform.position = Vector3.MoveTowards(this.transform.position, targetPosition, Time.deltaTime * 10);
        //    this.transform.position = targetPosition;
        //
        //    // Try moving to target vector with physics
        //    // Vector3 dir = (targetPosition - transform.position).normalized * 5f;
        //    // this.GetComponent<Rigidbody>().velocity = dir;
        //}
        //else
        //{
        //    GetComponent<Rigidbody>().isKinematic = false;
        //    //this.gameObject.transform.position = new Vector3(-30f, 0f, 0f);
        //}

    }

}
