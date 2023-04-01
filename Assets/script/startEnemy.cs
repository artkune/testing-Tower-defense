using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startEnemy : MonoBehaviour
{
    public int _NumberEnemy;
    public bool _isCreateEnemy = true ;

    public float _NumberUpgradeEnemy = 0;
    public float _TimeUpgradeEnemy = 0;
    public GameObject[] _Enemy;

    public int _num;
    public float _numTime;
    // Start is called before the first frame update
    void Start()
    {
        _num = _NumberEnemy;
        _numTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        CreateEnemy();

        FEnemy();

        _TimeUpgradeEnemy += Time.deltaTime;
        if(_TimeUpgradeEnemy > 60)
        {

            _NumberUpgradeEnemy += 0.5f;
            _TimeUpgradeEnemy = 0;
        }
        
    }
    void CreateEnemy()
    {
        if (_isCreateEnemy)
        {
            _numTime += Time.deltaTime;
            if (_numTime > 0.5)
            {

                GameObject _gobj = Instantiate(_Enemy[Random.Range(0,_Enemy.Length)]);
                _gobj.GetComponent<Enemy>().setUpgradeEnemy(_NumberUpgradeEnemy);
                _num--;
                _numTime = 0;
            }
            if (_num <= 0)
            {
                _isCreateEnemy = false;
                _num = _NumberEnemy;
            }

        }
    }
    void FEnemy()
    {
        if (!_isCreateEnemy)
        {
            GameObject[] Enemy;
            Enemy = GameObject.FindGameObjectsWithTag("Enemy");

            if (Enemy.Length == 0)
            {
                _isCreateEnemy = true;
            }
        }
           
    }
}
