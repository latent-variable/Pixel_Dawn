using UnityEngine;
using System.Collections;

public class LookAtMouse : MonoBehaviour
{

    float smooth = 5.0f;
    float tiltAngle = 60.0f;

    void Update()
    {
        // Smoothly tilts a transform towards a target rotation.
        float tiltAroundZ = Input.GetAxis("Horizontal") * tiltAngle;
        float tiltAroundX = Input.GetAxis("Vertical") * tiltAngle;

        Quaternion target = Quaternion.Euler(tiltAroundX, 0, tiltAroundZ);

        // Dampen towards the target rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
    }

    /*
        
       // var pos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
       // pos = Camera.main.ScreenToWorldPoint(pos);
       // transform.position = pos;
        
        
        Vector2 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector2.one);
        
        */

}