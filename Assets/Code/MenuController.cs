using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuC : MonoBehaviour
{
    [SerializeField] private GameObject mainPanel;    // 主菜单面板
    [SerializeField] private GameObject introPanel;   // 介绍面板

    // 开始游戏
    public void StartGame()
    {
        SceneManager.LoadScene("MainScene");  // 确保这里的场景名与你的游戏场景名一致
    }

    // 显示游戏介绍
    public void ShowIntro()
    {
        mainPanel.SetActive(false);
        introPanel.SetActive(true);
    }

    // 返回主菜单
    public void BackToMain()
    {
        mainPanel.SetActive(true);
        introPanel.SetActive(false);
    }

    // 退出游戏
    public void ExitGame()
    {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}