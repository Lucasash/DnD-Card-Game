using Kalkatos.DottedArrow;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testScript : MonoBehaviour
{
    [SerializeField] private Transform origin;
    [SerializeField] private Arrow arrow;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            arrow.SetupAndActivate(origin);
        else if (Input.GetMouseButtonUp(0))
            arrow.Deactivate();
    }
}
