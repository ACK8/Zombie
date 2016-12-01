﻿using UnityEngine;
using System.Collections;

public class TestRay : MonoBehaviour
{
    void Start()
    {

    }
    
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, 200))
            {
                Menu.Instance.SelectMenu(hit.collider.name);
            }
        }

        if(Input.GetKeyDown(KeyCode.A))
        {
            Menu.Instance.SwitchDisplay();
        }
    }
}
