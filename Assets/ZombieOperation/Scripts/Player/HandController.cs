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
    public GameObject operatingObject;

    private SteamVR_TrackedObject trackedComponent;
    private Syringe syringeComponent;
    private Operating operatingComponent;

    void Start()
    {
        trackedComponent = GetComponent<SteamVR_TrackedObject>();

        vrControllerObject.SetActive(false);

        //注射器を一旦停止
        syringeObject.SetActive(false);
        syringeComponent = syringeObject.GetComponent<Syringe>();
        syringeComponent.enabled = false;

        //操作器を一旦停止
        operatingObject.SetActive(false);
        operatingComponent = operatingObject.GetComponent<Operating>();
        operatingComponent.enabled = false;

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
                operatingObject.SetActive(true);
                operatingComponent.enabled = true;

                break;
        }
        SyringeEnabled(false);
    }

    void Update()
    {
        var device = SteamVR_Controller.Input((int)trackedComponent.index);

        //手に持ってるごとの処理
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

                //命令を決定
                if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
                {
                    operatingComponent.Decision();
                }

                break;
        }

        //注射器と操作器の入れ替え
        if (device.GetPressDown(SteamVR_Controller.ButtonMask.ApplicationMenu))
        {
            if (handType == HandType.Syringe)
            {
                handType = HandType.OperatingDevice;
                syringeObject.SetActive(false);
                syringeComponent.enabled = false;
                operatingObject.SetActive(true);
                operatingComponent.enabled = true;
            }
            else if (handType == HandType.OperatingDevice)
            {
                handType = HandType.Syringe;
                operatingObject.SetActive(false);
                operatingComponent.enabled = false;
                syringeObject.SetActive(true);
                syringeComponent.enabled = true;
            }
        }
    }

    public void SyringeEnabled(bool f)
    {
        syringeObject.SetActive(f);
        syringeComponent.enabled = f;
    }
}
