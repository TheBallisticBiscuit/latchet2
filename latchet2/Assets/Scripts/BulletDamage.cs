using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    // Start is called before the first frame update
    public int damage = 20;
    public List<Health> friendlyTargets;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Health hpScript = other.gameObject.GetComponent<Health>();
        if (hpScript != null && !(this.friendlyTargets.Contains(hpScript)))
        {
            hpScript.TakeDamage(damage);
        }
    }
}
