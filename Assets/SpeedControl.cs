using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Aeroplane;

public class SpeedControl : MonoBehaviour
{
    AeroplaneController ac;

	void Start()
    {
        ac = GetComponent<AeroplaneController>();
	}
	
	void Update()
    {
        if (Input.GetKeyDown(KeyCode.PageUp))
        {
            ac.m_MaxEnginePower = Mathf.Min(4e7f, ac.m_MaxEnginePower * 10);
            var r = transform.eulerAngles;
            r.x = 0;
            transform.eulerAngles = r;
        }
        if (Input.GetKeyDown(KeyCode.PageDown))
            ac.m_MaxEnginePower = Mathf.Max(40, ac.m_MaxEnginePower / 10);
    }
}
