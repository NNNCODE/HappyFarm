using UnityEngine;
using UnityEngine.UI;  // 确保添加这个引用

public class DirtInteraction : MonoBehaviour
{
    [SerializeField] private Image buttonImage;      // 序列化使其在Inspector中可见
    [SerializeField] private Sprite digSprite;       // dig挖土图片
    [SerializeField] private Sprite seedSprite;      // seed种子图片
    [SerializeField] private GameObject SM_Env_Dirt_01;  // 土地物体
    [SerializeField] private Material dugSoilMaterial;   // 挖过的土材质
    
    private Material originalMaterial;  
    private bool isDug = false;        

    void Start()
    {
        if (SM_Env_Dirt_01 != null)
        {
            originalMaterial = SM_Env_Dirt_01.GetComponent<MeshRenderer>().material;
        }
        
        if (buttonImage != null && digSprite != null)
        {
            buttonImage.sprite = digSprite;
        }
    }

    public void OnShovelHit()
    {
        if (!isDug && SM_Env_Dirt_01 != null && dugSoilMaterial != null && buttonImage != null && seedSprite != null)
        {
            SM_Env_Dirt_01.GetComponent<MeshRenderer>().material = dugSoilMaterial;
            buttonImage.sprite = seedSprite;
            isDug = true;
        }
    }
}