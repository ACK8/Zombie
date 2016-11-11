using UnityEngine;
using System.Collections;

public class Cardkey : MonoBehaviour
{
    [SerializeField]
    private Door doorScript;
    [SerializeField]
    private int cardKeyID;

    void Start()
    {

    }

    void Update()
    {

    }

    void OnTriggerEnter(Collider hit)
    {
        if (hit.tag == "Key")
        {
            //カードキーIDとカードIDが同じ時にドアを施錠
            if (cardKeyID == hit.GetComponent<Key>().cardID)
            {
                doorScript.MoveDoor();
            }
        }
    }
}
