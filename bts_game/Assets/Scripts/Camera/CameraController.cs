using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Collections;
[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour {
    public float lookSpeed = 2f;
    public float moveSpeed = 2f;

    Vector3 point = Vector3.zero;
    Quaternion rotation;
    bool follow = false;
    bool lookat = false;

    // Update is called once per frame
    void Update() {
        Move();
        Look();
    }

    void Move()
    {
        if (!follow)
            return;        
            transform.position = Vector3.Lerp(transform.position, point, moveSpeed * Time.deltaTime);
    }
    void Look()
    {
        if (!lookat)
            return;
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, lookSpeed * Time.deltaTime);
    }

    public void Follow(Vector3 point)
    {
        this.point = point;
        follow = true;
    }
    public void LookAt(Quaternion rotation)
    {
        this.rotation = rotation;
        lookat = true;
    }
    public void LookAt(Vector3 direction)
    {
        this.rotation = Quaternion.LookRotation(direction);
    }
    public void StopFollow()
    {
        follow = false;
    }
    public void StopLook()
    {
        lookat = false;
    }
    public void ResumeFollow()
    {
        follow = true;
    }
    public void ResumeLook()
    {
        lookat = true;
    }
}
