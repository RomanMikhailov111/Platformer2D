using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyComponent : MonoBehaviour
    
{
    [SerializeField]
    private GameObject _objectToDestroy;

    // Start is called before the first frame update
   public void DestroyObject()
    {
        Destroy(_objectToDestroy);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
