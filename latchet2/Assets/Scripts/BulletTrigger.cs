using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTrigger : MonoBehaviour
{
    public GameObject bulletPrefab;
    public List<Health> friendlyTargets;

    // Start is called before the first frame update
    void Start()
    {
        friendlyTargets.Add(GetComponentInParent<Health>());
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet.GetComponent<BulletDamage>().friendlyTargets = this.friendlyTargets;
        }
    }
}
