using UnityEngine;
using System.Collections;

public enum HandType
{
    VRController,
    Syringe,
    OperatingDevice,
}

public class HandController : MonoBehaviour
{
    public HandType handType;
    public GameObject vrControllerObject;
    public GameObject syringeObject;
    public GameObject operatingDeviceObject;

    private GameObject currentObject;
    private SteamVR_TrackedObject trackedComponent;
    private Syringe syringeComponent;

    void Start ()
    {
        trackedComponent = GetComponent<SteamVR_TrackedObject>();

        switch (handType)
        {
            case HandType.VRController:
                currentObject = Instantiate(vrControllerObject);
                break;

            case HandType.Syringe:
                Debug.Log("Syringe");

                currentObject = Instantiate(syringeObject);
                syringeComponent = currentObject.GetComponent<Syringe>();
                
                break;

            case HandType.OperatingDevice:
                currentObject = Instantiate(operatingDeviceObject);

                break;
        }

        currentObject.transform.SetParent(transform);
    }

    void Update()
    {
        var device = SteamVR_Controller.Input((int)trackedComponent.index);

        switch (handType)
        {
            case HandType.VRController:
                break;

            case HandType.Syringe:
                //注射を打つ
                if (device.GetPress(SteamVR_Controller.ButtonMask.Trigger))
                {
                    syringeComponent.OnInjection();
                }
                else
                {
                    syringeComponent.OffInjection();
                }

                break;

            case HandType.OperatingDevice:

                break;
        }
    }
}
