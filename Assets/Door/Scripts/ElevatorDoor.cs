using UnityEngine;
using System.Collections;

public class ElevatorDoor : MonoBehaviour
{
    [SerializeField]
    private Door[] door;
    private bool isOpen = false;    //現在ドアが開いているか

    void Start()
    {

    }

    //CardKeyから呼ばれる
    public void MoveDoor()
    {
        isOpen = !isOpen;
    }

    void Update()
    {
        if (isOpen)
        {
            door[0].OpenDoor();
            door[1].CloseDoor();
        }
        else
        {
            door[0].CloseDoor();
            door[1].OpenDoor();
        }
    }
}
