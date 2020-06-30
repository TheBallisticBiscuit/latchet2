using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool dashing;
    public float dashRange;
    public float dashSpeed;
    public Transform dashCastPoint;
    // Start is called before the first frame update
    void Start()
    {
        dashing = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!this.dashing && Input.GetMouseButtonUp(1))
        {
            Vector3 target = this.CalculateDashPoint();
            this.dashing = true;
            this.StartCoroutine("Dash", target);
        }
    }

    private Vector3 CalculateDashPoint()
    {
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(this.dashCastPoint.position, this.dashCastPoint.forward, out hit, this.dashRange))
        {
            return hit.point;
        }
        else
        {
            return this.transform.position;
        }
    }

    private IEnumerator Dash(Vector3 target)
    {
        while(Vector3.Distance(target, this.transform.position) > 0.5)
        {
            Vector3 direction = target - this.transform.position;
            this.transform.position = Vector3.MoveTowards(this.transform.position, target, Time.deltaTime * dashSpeed);
            yield return null;
        }
        this.dashing = false;
    }
}
