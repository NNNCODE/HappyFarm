using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolInteraction : MonoBehaviour
{
    [SerializeField] private ButtonController buttonController;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Shovel") || other.CompareTag("SeedBag") || other.CompareTag("WaterCan"))
        {
            buttonController.SetCurrentTool(other.gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Shovel") || other.CompareTag("SeedBag") || other.CompareTag("WaterCan"))
        {
            buttonController.SetCurrentTool(null);
        }
    }
}