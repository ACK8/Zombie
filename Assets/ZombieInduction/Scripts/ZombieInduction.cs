using UnityEngine;
using System.Collections;

public class ZombieInduction : MonoBehaviour
{
    [SerializeField]
    private float maxRayDist = 100f;

    private Zombie m_Zombie;
    private LineRenderer line;
    private RaycastHit hit;
    private Ray ray;
    private SteamVR_TrackedObject trackedObject;

    void Start()
    {
        line = GetComponent<LineRenderer>();
        trackedObject = GetComponent<SteamVR_TrackedObject>();
    }

    void Update()
    {
        var device = SteamVR_Controller.Input((int)trackedObject.index);

        ray.direction = this.transform.forward;
        ray.origin = this.transform.position;

        line.SetPosition(0, ray.origin);
        line.SetPosition(1, ray.GetPoint(maxRayDist));

        if (Physics.Raycast(ray, out hit, maxRayDist))
        {
            if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
            {
                if (hit.collider.tag == "Zombie")
                {
                    m_Zombie = hit.collider.gameObject.GetComponent<Zombie>();
                }

                if (hit.collider.tag == "Floor")
                {
                    if (m_Zombie != null)
                    {
                        m_Zombie.targetPos = hit.point;
                        m_Zombie.isMove = true;
                    }
                }
            }
        }
    }
}
