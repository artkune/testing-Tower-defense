using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyType _EnemyType;
    public float _HP;
    public float _Speed;
    public float _Upgrade;


    [Header("move Settings")]
    public bool E_isSlow;
    public Vector3 _ponmove;
    private mapEnemyMove _mapmove;
    private int numberPon = 1;
    // Start is called before the first frame update
    void Start()
    {
        setEnemy();
        _mapmove = GameObject.Find("map").GetComponent<mapEnemyMove>();
    }

    // Update is called once per frame
    void Update()
    {
        setmoveEnemy();

        if (_HP < 0)
        {
            dead();
        }
    }
    void setmoveEnemy()
    {
        if(_ponmove == transform.position)
        {
            numberPon++;
            
        }
        if (numberPon >= _mapmove._Ponmove.Length)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _ponmove = _mapmove._Ponmove[numberPon];
            transform.LookAt(_ponmove);
            float _speedUse = _Speed ;
            if (E_isSlow)
            {
                _speedUse = _Speed * (1 - (_Upgrade / 100));
            }
            transform.position = Vector3.MoveTowards(transform.position, _ponmove,_speedUse * Time.deltaTime);
        }

        
    }
    void setEnemy()
    {
        switch (_EnemyType)
        {
            case EnemyType.Type_1 :
                _HP = 30 ;
                _Speed = 5 ;
                break;

            case EnemyType.Type_2 :
                _HP = 50  ;
                _Speed = 3 ;
                break;
            case EnemyType.Type_3 :
                _HP = 100 ;
                _Speed = 1;
                break;

        }
        _HP = _HP*(1 + (_Upgrade / 100));
        _Speed = _Speed *(1 + (_Upgrade / 100));
    }
    public void setUpgradeEnemy(float _numUpgrade)
    {
        _Upgrade = _numUpgrade;
        
    }

    public void Attack(float inDamage)
    {
        _HP -= inDamage;
        if (_HP < 0)
        {
            dead();
        }
    }
    public void Attack(float inDamage,bool inSlow)
    {
        _HP -= inDamage;
        if (_HP < 0)
        {
            dead();
        }
        E_isSlow = inSlow;
        
    }

    void dead()
    {
        Destroy(this.gameObject);
    }
}
public enum EnemyType {Type_1,Type_2,Type_3 }
