using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;

public class ServerStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        NetworkingManager.Singleton.StartHost();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
