using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulEffectTp : MonoBehaviour
{
    public GameObject GameObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      transform.position = gameObject.transform.position;
      
    }
}
