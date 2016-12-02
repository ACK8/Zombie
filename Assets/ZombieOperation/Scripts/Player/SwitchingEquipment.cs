using UnityEngine;
using System.Collections;

public class SwitchingEquipment : MonoBehaviour
{
    public Syringe syringeScript;
    public Operating operatingScript;
    
	void Start ()
    {

	}
	
	void Update ()
    {

    }

    public void ChangeSyringe()
    {
        syringeScript.enabled = true;
        operatingScript.enabled = false;
    }

    public void ChangeOperating()
    {
        syringeScript.enabled = false;
        operatingScript.enabled = true;
    }
}
