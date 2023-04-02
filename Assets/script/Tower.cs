using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Tower : MonoBehaviour
{
    public TowerType _TowerType;
    public float T_Firerate;
    public float T_Damage;
    public float T_Radius;

    public float T_TimeFirerate = 0;
    public GameObject T_Bullet;
    public List<GameObject> E_targetEnemy;

    
    // Start is called before the first frame update
    void Start()
    {
        setTower();
    }

    // Update is called once per frame
    void Update()
    {
        E_targetEnemy.RemoveAll(x => x == null);
        if(E_targetEnemy.Count != 0)
        {

            setTargetEnemy();

            shoot();


        }
        
        
    }
    void shoot()
    {
        T_TimeFirerate += Time.deltaTime;
        if(T_TimeFirerate > T_Firerate)
        {
            T_TimeFirerate = 0;


            GameObject _Bu = Instantiate(T_Bullet,this.transform.position,this.transform.rotation);
            _Bu.GetComponent<Bullet>()._Damage = T_Damage;
            _Bu.transform.position += Vector3.up/2;

        }

    }
    void setTargetEnemy()
    {
        Vector3 _target = Vector3.zero;

        switch (_TowerType)
        {
            case TowerType.Type_1:
                _target = MyMethods.MinDistance(E_targetEnemy, gameObject.transform).transform.position;
               
                break;
            case TowerType.Type_2:
                _target = MyMethods.MaxDistance(E_targetEnemy, gameObject.transform).transform.position;
                break;

            case TowerType.Type_3:
                _target = MyMethods.MinDistance(E_targetEnemy, gameObject.transform).transform.position;
                break;
        }
        
        _target.y = 0;
        this.gameObject.transform.LookAt(_target);
    }
    void setTower()
    {
        switch (_TowerType)
        {
            case TowerType.Type_1:
                T_Firerate = 0.5f;
                T_Damage = 3;
                T_Radius = 1;
                break;
            case TowerType.Type_2:
                T_Firerate = 2f;
                T_Damage = 10;
                T_Radius = 5;
                break;
            case TowerType.Type_3:
                T_Firerate = 1;
                T_Damage = 1;
                T_Radius = 3;
                break;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            E_targetEnemy.Add(other.gameObject);
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            E_targetEnemy.Remove(other.gameObject);
        }
    }
}
public enum TowerType { Type_1, Type_2, Type_3 }
