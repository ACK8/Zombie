using UnityEngine;
using System.Collections;

public class VRColtroller : MonoBehaviour
{
    private SteamVR_TrackedObject trackedComponent;

    void Start()
    {

    }

    void Update()
    {
        var device = SteamVR_Controller.Input((int)trackedComponent.index);

        if (device.GetPressDown(SteamVR_Controller.ButtonMask.ApplicationMenu))
        {

        }
    }
}
