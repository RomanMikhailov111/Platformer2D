using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Transform TeleportPosition;

    public void TeleportObject (GameObject ObjectToTeleport)
    {
        ObjectToTeleport.transform.position = TeleportPosition.position;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
