using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxInTower : MonoBehaviour
{
    public bool _isOnRaycast;
    int layerNumber = 6;
    int layerMask;
    Ray ray;
    RaycastHit hit;
    public GameObject Target;
    public Material  _hit_Material_Off, _hit_Material_On;

    public int T_NumberTower;
    public GameObject[] T_TowerInGame;
    // Start is called before the first frame update
    void Start()
    {
        layerMask = 1 <<layerNumber;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isOnRaycast)
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity,layerMask))
            {
                Debug.DrawLine(ray.origin, hit.point,Color.red);

                if (Target != null && Target.tag == "Boxin")
                {
                    MeshRenderer hit_Material = Target.transform.GetComponent<MeshRenderer>();

                    if (hit.collider.gameObject == Target)
                    {
                        hit_Material.material = _hit_Material_Off;
                        OnpushObj();
                    }
                    else
                    {
                        hit_Material.material = _hit_Material_On;
                    }
                    //hit_Material.color = Color.red;
                }
     
                Target = hit.collider.gameObject;
                

            }
        }
        
    }

    void OnpushObj()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SetTowerOn();
            Target.SetActive(false);
            //_isOnRaycast = false;
            gameObject.SetActive(false);
        }
    }
    public void SetTower(int innumber)
    {
        T_NumberTower = innumber;
    }
    void SetTowerOn()
    {
        Vector3 VTower = Target.transform.position;
        VTower.y = 0;
        Instantiate(T_TowerInGame[T_NumberTower],VTower,Quaternion.identity);
    }
}
