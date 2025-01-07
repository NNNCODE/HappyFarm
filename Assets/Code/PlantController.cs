using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantController : MonoBehaviour
{
    [SerializeField] private Button plantBtn;
    [SerializeField] private PlantLand farmland;

    void Start()
    {
        plantBtn = GetComponent<Button>();
        plantBtn.onClick.AddListener(OnPlantClick);
    }

    void OnPlantClick()
    {
        farmland.ChangePlantLand();
    }
}
