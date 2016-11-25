using UnityEngine;
using System.Collections;

public enum OperatingType
{
    Wait,
    Move,
    Following,
    PushObject,
}

public class Operating : MonoBehaviour
{
    public GameObject rayPointObject;
    public GameObject selectionTarget;
    public OperatingType operatingType;

    private LineRenderer line;
    private RaycastHit hit;
    private Ray ray;

    void Start ()
    {
        line = GetComponent<LineRenderer>();
        //line.enabled = false;
    }
	
	void Update ()
    {
        ray.direction = rayPointObject.transform.forward;
        ray.origin = rayPointObject.transform.position;

        line.SetPosition(0, ray.origin);
        line.SetPosition(1, ray.GetPoint(200));
        line.enabled = true;

        if (Physics.Raycast(ray, out hit, 200.0f))
        {
            selectionTarget.transform.position = hit.point;

            if (hit.collider.tag == "Zombie")
            {

                //m_Zombie = hit.collider.gameObject.GetComponent<Zombie>();
            }

            if (hit.collider.tag == "Floor")
            {
                /*
                if (m_Zombie != null)
                {
                    m_Zombie.target = hit.point;
                    m_Zombie.isMove = true;
                }
                */
            }
        }
        else
        {
            selectionTarget.transform.position = Vector3.zero;
        }

        switch (operatingType)
        {
            case OperatingType.Wait:

                break;

            case OperatingType.Move:

                break;

            case OperatingType.Following:

                break;

            case OperatingType.PushObject:

                break;
        }
    }

    public void Decision()
    {
        switch (operatingType)
        {
            case OperatingType.Wait:

                break;

            case OperatingType.Move:

                break;

            case OperatingType.Following:

                break;

            case OperatingType.PushObject:

                break;
        }
    }
}
