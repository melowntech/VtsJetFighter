using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailsShiftOrigin : VtsObjectShiftingOriginBase
{
    private TrailRenderer tr;

    private Vector3 p1;

    void Start()
    {
        tr = GetComponent<TrailRenderer>();
    }

    public override bool OnBeforeOriginShift(VtsMapShiftingOrigin vmfo)
    {
        p1 = transform.position;
        return true;
    }

    public override void OnAfterOriginShift()
    {
        Vector3 p2 = transform.position - p1;
        int cnt = tr.positionCount;
        Vector3[] ps = new Vector3[cnt];
        tr.GetPositions(ps);
        for (int i = 0; i < cnt; i++)
            ps[i] += p2;
        tr.SetPositions(ps);
    }
}
