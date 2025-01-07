using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolManager : MonoBehaviour
{
    [SerializeField] private GameObject shovel;
    [SerializeField] private GameObject seedBag;
    [SerializeField] private GameObject waterCan;

    private Dictionary<string, Vector3> originalPositions = new Dictionary<string, Vector3>();

    void Start()
    {
        // 记录工具初始位置
        originalPositions.Add("Shovel", shovel.transform.position);
        originalPositions.Add("SeedBag", seedBag.transform.position);
        originalPositions.Add("WaterCan", waterCan.transform.position);
    }

    public void ReturnToolToOriginalPosition(GameObject tool)
    {
        if (originalPositions.ContainsKey(tool.name))
        {
            tool.transform.position = originalPositions[tool.name];
            tool.transform.rotation = Quaternion.identity;
        }
    }
}