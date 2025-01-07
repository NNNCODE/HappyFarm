using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonController : MonoBehaviour
{
    [SerializeField] private Button actionBtn;
    [SerializeField] private Image actionImage;
    [SerializeField] private Sprite digSprite, plantSprite, waterSprite, harvestSprite;
    [SerializeField] private Land farmland;
    [SerializeField] private ToolManager toolManager;
    [SerializeField] private GameObject carrotPrefab;

    private GameObject currentTool;

    void Start()
    {
        actionBtn = GetComponent<Button>();
        actionImage = GetComponent<Image>();

        SetButtonState("Dig");
        actionBtn.onClick.AddListener(OnButtonClick);
    }

    public void SetCurrentTool(GameObject tool)
    {
        currentTool = tool;
    }

    void OnButtonClick()
    {
        if (currentTool == null) return;

        switch (actionImage.sprite.name)
        {
            case "dig":
                if (currentTool.CompareTag("Shovel"))
                {
                    farmland.ChangeLandState(LandState.Dug);
                    toolManager.ReturnToolToOriginalPosition(currentTool);
                    SetButtonState("Plant");
                }
                break;

            case "plant":
                if (currentTool.CompareTag("SeedBag"))
                {
                    farmland.ChangeLandState(LandState.Planted);
                    toolManager.ReturnToolToOriginalPosition(currentTool);
                    SetButtonState("Water");
                }
                break;

            case "water":
                if (currentTool.CompareTag("WaterCan"))
                {
                    farmland.ChangeLandState(LandState.Watered);
                    toolManager.ReturnToolToOriginalPosition(currentTool);
                    SpawnCarrot();
                    SetButtonState("Harvest");
                }
                break;
        }
    }

    void SetButtonState(string state)
    {
        switch (state)
        {
            case "Dig":
                actionImage.sprite = digSprite;
                break;
            case "Plant":
                actionImage.sprite = plantSprite;
                break;
            case "Water":
                actionImage.sprite = waterSprite;
                break;
            case "Harvest":
                actionImage.sprite = harvestSprite;
                break;
        }
    }

    void SpawnCarrot()
    {
        GameObject carrot = Instantiate(carrotPrefab, farmland.transform.position + Vector3.up, Quaternion.identity);
    }
}