using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    CharacterController controller;
    [SerializeField]
    GameObject camera;
	// Use this for initialization
	void Start () {
        controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        Move();
	}

    float yVec=0;
    float glavity=0.1f;
    void Move()
    {
        if (controller.isGrounded == false)
            yVec += Physics.gravity.y*Time.deltaTime;
        else
            yVec = 0;
        Vector3 movevec=Vector3.zero;
        if (Input.GetKey(KeyCode.W))
            movevec += Vector3.Scale(Vector3.right + Vector3.forward, camera.transform.forward) ;
        if (Input.GetKey(KeyCode.A))
            movevec += Vector3.Scale(Vector3.right + Vector3.forward, -camera.transform.right) ;
        if (Input.GetKey(KeyCode.D))
            movevec += Vector3.Scale(Vector3.right + Vector3.forward, camera.transform.right);
        if (Input.GetKey(KeyCode.S))
            movevec += Vector3.Scale(Vector3.right + Vector3.forward, -camera.transform.forward);
        if (Input.GetKey(KeyCode.Space) && controller.isGrounded)
            yVec = 2;
        movevec = movevec.normalized*6 *Time.deltaTime+Vector3.up*yVec;
        controller.Move(movevec);
    }
}
