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




        }
        
        
    }
    void setTargetEnemy()
    {
        GameObject _tr = new GameObject();

        switch (_TowerType)
        {
            case TowerType.Type_1:
                _tr = MyMethods.MinDistance(E_targetEnemy, gameObject.transform);

                break;
            case TowerType.Type_2:
                _tr = MyMethods.MaxDistance(E_targetEnemy, gameObject.transform);

                break;
            case TowerType.Type_3:
                _tr = MyMethods.MinDistance(E_targetEnemy, gameObject.transform);

                break;
        }
        Vector3 _target = _tr.transform.position;
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
                T_Firerate = 0.5f;
                T_Damage = 3;
                T_Radius = 5;
                break;
            case TowerType.Type_3:
                T_Firerate = 0.5f;
                T_Damage = 3;
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
