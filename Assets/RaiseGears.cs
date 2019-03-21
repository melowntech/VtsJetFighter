using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaiseGears : MonoBehaviour
{
	void Start()
    {
        var m_Animator = GetComponent<Animator>();
        m_Animator.SetInteger("GearState", -1);
    }
}
