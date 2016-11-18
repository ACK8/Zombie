using UnityEngine;
using System.Collections;

public class Syringe : MonoBehaviour
{
    CapsuleCollider injectionJudgment;

    void Awake()
    {
        injectionJudgment = GetComponent<CapsuleCollider>();
        injectionJudgment.enabled = false;
    }

	void Update ()
    {
	
	}

    void OnCollisionStay(Collision collisionInfo)
    {
        Debug.Log("Hit");
        if(collisionInfo.transform.tag == "Zombie")
        {

        }
    }

    //注射をしている状態にする
    public void OnInjection()
    {
        injectionJudgment.enabled = true;
    }

    //注射をしていない状態にする
    public void OffInjection()
    {
        injectionJudgment.enabled = false;
    }
}
