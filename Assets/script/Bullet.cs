using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float _Speed;
    public float _Damage;
    public bool _isSlow;
    public GameObject _Bomb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * _Speed * Time.deltaTime);
        Destroy(gameObject,10f);

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            Enemy _other_Enemy = other.GetComponent<Enemy>();
            _other_Enemy.Attack(_Damage,_isSlow);
            Instantiate(_Bomb, this.transform.position, this.transform.rotation);
            Destroy(gameObject);
        }
    }
}
