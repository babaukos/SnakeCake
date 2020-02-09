// ver. 0.1.2
// Ограничивающее поле
// Michael Khmelevsky

using UnityEngine;

[ExecuteInEditMode]
public class ClampArea : MonoBehaviour 
{
    public Vector3 trackZone;

    //
    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position, trackZone);
    }
    //
    public Vector3 GetTruePos(Vector3 qp)
    {
        // zone
        var p = transform.position;
        var x = Mathf.Clamp(qp.x, p.x - trackZone.x/2, p.x + trackZone.x/2);     
        var y = Mathf.Clamp(qp.y, p.y - trackZone.y/2, p.y + trackZone.y/2);
        var z = Mathf.Clamp(qp.z, p.z - trackZone.z/2, p.z + trackZone.z/2);
        //
        return new Vector3(x, y, z);
    }
}
