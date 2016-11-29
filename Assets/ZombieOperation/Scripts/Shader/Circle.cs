using UnityEngine;
using System.Collections;

public class Circle : MonoBehaviour
{
    public Material[] materials;

    private Vector3 point;

    void Start ()
    {
    }
	
	void Update ()
    {
        for (int i = 0; i < materials.Length; i++)
        {
            materials[i].SetFloat("_Radius", 0.5f);
            materials[i].SetVector("_Point", point);
        }
    }

    public void SetPoint(Vector3 newPoint)
    {
        point = newPoint;
    }
}
