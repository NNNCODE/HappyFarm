using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LandState
{
    Normal,
    Dug,
    Planted,
    Watered
}

public class Land : MonoBehaviour
{
    [SerializeField] private Material normalMat, dugMat, plantedMat, wateredMat;
    private MeshRenderer meshRenderer;
    private LandState currentState = LandState.Normal;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    public void ChangeLandState(LandState newState)
    {
        currentState = newState;

        switch (currentState)
        {
            case LandState.Normal:
                meshRenderer.material = normalMat;
                break;
            case LandState.Dug:
                meshRenderer.material = dugMat;
                break;
            case LandState.Planted:
                meshRenderer.material = plantedMat;
                break;
            case LandState.Watered:
                meshRenderer.material = wateredMat;
                break;
        }
    }
}