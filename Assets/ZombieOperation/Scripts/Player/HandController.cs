using UnityEngine;
using System.Collections;

//手に装備する種類
public enum HandType
{
    VRController,
    Syringe,
    OperatingDevice,
}

//手関係の処理をコントロールするクラス
public class HandController : MonoBehaviour
{
    public HandType handType;
    public GameObject vrControllerObject;
    public GameObject syringeObject;
    public GameObject operatingDeviceObject;

    private SteamVR_TrackedObject trackedComponent;
    private Syringe syringeComponent;

    void Start ()
    {
        trackedComponent = GetComponent<SteamVR_TrackedObject>();

        vrControllerObject.SetActive(false);

        //注射器を一旦停止
        syringeObject.SetActive(false);
        syringeComponent = syringeObject.GetComponent<Syringe>();
        syringeComponent.enabled = false;

        //operatingDeviceObject.SetActive(false);

        switch (handType)
        {
            case HandType.VRController:
                vrControllerObject.SetActive(true);

                break;

            case HandType.Syringe:
                syringeObject.SetActive(true);
                syringeComponent.enabled = true;

                break;

            case HandType.OperatingDevice:
                operatingDeviceObject.SetActive(true);

                break;
        }
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
