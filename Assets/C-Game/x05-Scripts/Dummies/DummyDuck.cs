using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyDuck : MonoBehaviour
{
    [SerializeField] Transform dummy;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(dummy.TransformPoint(Vector2.zero));
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(dummy.TransformPoint(Vector2.zero));
    }
}
