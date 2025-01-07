using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantLand : MonoBehaviour
{
    [SerializeField] private Material plantedMat;
    private MeshRenderer meshRenderer;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    public void ChangePlantLand()
    {
        meshRenderer.material = plantedMat;
    }
}