﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoLaserRifle : MonoBehaviour
{
    public GameObject m_shotPrefab;

    RaycastHit hit;
    float range = 1000.0f;

    void Update()
    {
        if(GameObject.Find("Endpoint_Sensor").GetComponent<LaserRifleActivation>().canShoot)
        {
            // Vector3 target = GameObject.Find("Endpoint_Sensor").GetComponent<LaserRifleActivation>().target;
            // shootRay(target);
            GameObject target = GameObject.Find("Endpoint_Sensor").GetComponent<LaserRifleActivation>().target;
            shootRay(target);
        }
    }

    void shootRay(GameObject target)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, range))
        {
            Vector3 target_position = target.transform.position;
            Debug.Log(target_position);
            GameObject laser = GameObject.Instantiate(m_shotPrefab, transform.position, transform.rotation) as GameObject;
            laser.GetComponent<BeamBehavior>().setTarget(target_position);
            GameObject.Destroy(laser, 1f);
        }
    }
}
