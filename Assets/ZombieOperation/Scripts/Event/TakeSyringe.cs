using UnityEngine;
using System.Collections;

public class TakeSyringe : MonoBehaviour
{
    [SerializeField]
    private GameObject syringe;

    private SteamVR_TrackedObject trackedComponent;
    private SteamVR_Controller.Device device;

    void Start()
    {
        trackedComponent = gameObject.transform.parent.GetComponent<SteamVR_TrackedObject>();
        syringe.SetActive(false);
    }

    void Update()
    {
        device = SteamVR_Controller.Input((int)trackedComponent.index);
    }

    void OnCollisionEnter(Collision hit)
    {
        if (hit.collider.tag == "Syringe")
        {
            if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
            {
                syringe.SetActive(true);
                Destroy(hit.gameObject);
                Destroy(this);
            }
        }
    }
}
