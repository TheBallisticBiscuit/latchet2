using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    // Start is called before the first frame update
    public int damage = 20;
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
        if (hpScript != null)
        {
            hpScript.TakeDamage(damage);
        }
    }
}
