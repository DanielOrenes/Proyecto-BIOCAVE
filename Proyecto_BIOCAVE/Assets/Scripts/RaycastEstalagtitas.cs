using UnityEngine;

public class RaycastEstalagtitas : MonoBehaviour
{
    RaycastHit hit1;
    RaycastHit hit2;
    RaycastHit hit3;
    public float offset;

    void Start()
    {
        offset = 0.1f;
        Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up), out hit1);

        Physics.Raycast(new Vector3(hit1.point.x, hit1.point.y - hit1.distance / 2, hit1.point.z), transform.TransformDirection(Vector3.down), out hit2);

        Physics.Raycast(hit2.point, transform.TransformDirection(Vector3.up), out hit3);

        gameObject.transform.position = new Vector3(hit3.point.x, gameObject.transform.position.y + hit3.distance + offset, hit3.point.z);
    }

    void Update()
    {     
        Debug.DrawRay(hit2.point, transform.TransformDirection(Vector3.up) * hit3.distance, Color.yellow);

        
    }
}
