using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool dashing;
    public float dashRange;
    public float dashSpeed;
    //public Rigidbody rb;
    public Transform dashCastPoint;
    // Start is called before the first frame update
    private Vector3 target;

    void Start()
    {
        dashing = false;
        //rb = this.GetComponent<Rigidbody>();
        //rb.velocity = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        //rb.velocity = Vector3.zero;
        if (Input.GetMouseButtonUp(1))
        {
            target = this.CalculateDashPoint();
            if (target != Vector3.zero)
            {
                this.dashing = true;
                this.StopCoroutine("Dash");
                this.transform.parent = null;
                this.StartCoroutine("Dash", target);
            }
        }
    }

    private void LateUpdate()
    {

    }

    private Vector3 CalculateDashPoint()
    {
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(this.dashCastPoint.position, this.dashCastPoint.forward, out hit, this.dashRange))
        {
            return dashCastPoint.forward;
        }
        else
        {
            return Vector3.zero;
        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log("COLLIDED");
    //    this.dashing = false;
    //    //this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
    //    if (collision.collider.gameObject.GetComponent<Grabbable>())
    //    {
    //        this.gameObject.transform.SetParent(collision.transform);
    //    }
    //}

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        this.dashing = false;
        //Move backwards one frame to prevent from sticking to walls
        this.GetComponent<CharacterController>().Move((target * (Time.deltaTime * -1)));
        //this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        //if (collision.collider.gameObject.GetComponent<Grabbable>())
        //{
        //    this.gameObject.transform.SetParent(hit.transform);
        //}
    }

    private IEnumerator Dash(Vector3 direction)
    {
        while(this.dashing == true)
        {
            this.GetComponent<CharacterController>().Move((direction * (Time.deltaTime * dashSpeed)));
            //this.rb.MovePosition(transform.position + (direction * (Time.deltaTime * dashSpeed)));
            yield return null;
        }
    }
}
