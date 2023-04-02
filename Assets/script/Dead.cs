using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead : MonoBehaviour
{
    public float _TimeDead;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, _TimeDead);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
