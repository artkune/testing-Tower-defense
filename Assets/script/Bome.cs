using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bome : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            Enemy _other_Enemy = other.GetComponent<Enemy>();
            _other_Enemy.Attack(Random.Range(8,11));
        }
    }
}
