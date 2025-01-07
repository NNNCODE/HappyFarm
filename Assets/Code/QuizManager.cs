using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit;

public class QuizManager : MonoBehaviour
{
    [Header("UI References")]
    public TextMeshProUGUI Question;
    public TextMeshProUGUI Score;
    public Button ButtonT;
    public Button ButtonF;
    public GameObject Correct;
    public GameObject wrong;
    public TextMeshProUGUI explanationText;

    [Header("Questions")]
    private string[] questions = new string[10];
    private bool[] answers = new bool[10];
    private string[] explanations = new string[10];
    private int currentQuestionIndex = 0;
    private int score = 0;
    void SetupButtons()
    {
        // 添加XR交互支持
        XRSimpleInteractable trueInteractable = ButtonT.GetComponent<XRSimpleInteractable>();
        if (trueInteractable != null)
        {
            trueInteractable.selectEntered.AddListener((args) => CheckAnswer(true));
        }

        XRSimpleInteractable falseInteractable = ButtonF.GetComponent<XRSimpleInteractable>();
        if (falseInteractable != null)
        {
            falseInteractable.selectEntered.AddListener((args) => CheckAnswer(false));
        }

        // 设置普通按钮点击事件
        ButtonT.onClick.AddListener(() => CheckAnswer(true));
        ButtonF.onClick.AddListener(() => CheckAnswer(false));
    }
    void Start()
    {
        InitializeQuestions();
        SetupButtons();
        DisplayQuestion();
        UpdateScore();


        // 隐藏正确/错误图片
        Correct.SetActive(false);
        wrong.SetActive(false);
        explanationText.gameObject.SetActive(false);
    }

    void InitializeQuestions()
    {
        // 设置5个问题，把这些替换成你的实际问题
        questions[0] = "Tomato plants need to be supported by stakes or cages because their stems are not strong enough to hold the fruit.";
        questions[1] = "You can plant carrots and potatoes in the same hole to save space in your garden";
        questions[2] = "If you see green spots on a potato, it means it's getting healthier.";
        questions[3] = "Tomatoes will continue to ripen after being picked from the plant.";
        questions[4] = "The orange part of the carrot we eat is actually the plant's root.";
        questions[5] = "Potato plants produce small green fruits that look like tomatoes, which are safe to eat..";
        questions[6] = "Carrots will grow larger if you leave them in the ground longer. ";
        questions[7] = "All tomato varieties turn red when they're ripe.";
        questions[8] = "Growing tomatoes next to potatoes in your garden increases the risk of disease for both plants.";
        questions[9] = "Carrots grow sweeter if exposed to cold temperatures before harvest.";


        answers[0] = true;
        answers[1] = false;
        answers[2] = false;
        answers[3] = true;
        answers[4] = true;
        answers[5] = false;
        answers[6] = true;
        answers[7] = false;
        answers[8] = true;
        answers[9] = true;

        explanations[0] = "Tomato plants have weak stems and need support to grow properly and hold their fruit.";
        explanations[1] = "They need different growing conditions and will compete for nutrients.";
        explanations[2] = "Green spots indicate the presence of solanine, which is toxic.";
        explanations[3] = "Tomatoes can continue to ripen due to ethylene gas production after picking.";
        explanations[4] = "The orange part of a carrot is indeed the root, specifically the taproot.";
        explanations[5] = "These fruits are toxic and should never be eaten.";
        explanations[6] = "While carrots will grow larger, they may become woody and lose flavor if left too long.";
        explanations[7] = "Some varieties stay yellow, orange, or even purple when ripe.";
        explanations[8] = "Both plants can share diseases as they belong to the same family.";
        explanations[9] = "Cold temperatures cause the plant to convert starches to sugars.";

    }



    void DisplayQuestion()
    {
        if (currentQuestionIndex < questions.Length)
        {
            Question.text = questions[currentQuestionIndex];
            Correct.SetActive(false);
            wrong.SetActive(false);
            explanationText.gameObject.SetActive(false);

            // 确保按钮是激活的
            ButtonT.gameObject.SetActive(true);
            ButtonF.gameObject.SetActive(true);
        }
        else
        {
            // Quiz结束
            Question.text = "Congratulations!\nYour score: " + score;
            ButtonT.gameObject.SetActive(false);
            ButtonF.gameObject.SetActive(false);
        }
    }

    void CheckAnswer(bool playerAnswer)
    {
        bool isCorrect = playerAnswer == answers[currentQuestionIndex];

        // 显示正确/错误图片
        Correct.SetActive(isCorrect);
        wrong.SetActive(!isCorrect);

        if (!isCorrect && !string.IsNullOrEmpty(explanations[currentQuestionIndex]))
        {
            explanationText.gameObject.SetActive(true);
            explanationText.text = explanations[currentQuestionIndex];
        }


        if (isCorrect)
        {
            score += 10; // 每题20分
            UpdateScore();
        }

        // 延迟1.5秒后进入下一题
        Invoke("NextQuestion", 1.5f);
    }

    void NextQuestion()
    {
        currentQuestionIndex++;
        DisplayQuestion();
    }

    void UpdateScore()
    {
        Score.text = "score: " + score;
    }
}