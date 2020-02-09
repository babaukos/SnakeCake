// ver. 0.1
// Позволяет ограничивать перемещение обьекта
// Michael Khmelevsky

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ClampTransform : MonoBehaviour 
{
    [Space]
    [Tooltip("Исползовать ограничение по значению или")]
    public LimitVal limitRange;
    [Header("ORE")]
    [Space]
    [Tooltip("Исползовать ограничение по полю")]
    public LimitAre fieldController;

    [System.Serializable]
    public struct LimitVal
    {
        public bool xClamp;
        public float xRange;

        public bool yClamp;
        public float yRange;
    }

    [System.Serializable]
    public struct LimitAre
    {
        public bool areaClamp;
        public ClampArea clampArea;
    }



	// Use this for initialization
	void Start () 
    {
		
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (fieldController.clampArea != null)
        {
            if (fieldController.areaClamp)
            transform.position = fieldController.clampArea.GetTruePos(transform.position); 
        }
        else
            {
                float x, y;
                x = transform.position.x;
                if(limitRange.yClamp)
                {
                    x = Mathf.Clamp(x, -limitRange.xRange, limitRange.xRange);        
                }
                y = transform.position.y;
                if (limitRange.yClamp)
                {
                    y = Mathf.Clamp(y, -limitRange.yRange, limitRange.yRange);
                }
                transform.position = new Vector3(x, y, transform.position.z);
            }
	}

    //
    public void SetAreae(ClampArea areaTrack)
    {
        fieldController.clampArea = areaTrack;
    }
}
