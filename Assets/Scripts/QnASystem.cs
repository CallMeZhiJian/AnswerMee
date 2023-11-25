using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QnASystem : MonoBehaviour
{
    public List<QuestionData> listOfQuestion = new List<QuestionData>();

    public static int currID;

    //UI
    [SerializeField]
    private TextMeshProUGUI QuestionText;
    [SerializeField]
    private TextMeshProUGUI AnswerText_1, AnswerText_2, AnswerText_3, AnswerText_4;

    private void Awake()
    {
        ProcessData();

        QuestionText = GameObject.Find("QuestionBox").GetComponentInChildren<TextMeshProUGUI>();
        AnswerText_1 = GameObject.Find("Answer1").GetComponentInChildren<TextMeshProUGUI>();
        AnswerText_2 = GameObject.Find("Answer2").GetComponentInChildren<TextMeshProUGUI>();
        AnswerText_3 = GameObject.Find("Answer3").GetComponentInChildren<TextMeshProUGUI>();
        AnswerText_4 = GameObject.Find("Answer4").GetComponentInChildren<TextMeshProUGUI>();

        currID = 0;
    }

    public void ProcessData()
    {
        listOfQuestion.Clear();

        TextAsset dataFile = Resources.Load<TextAsset>("QuestionData/QuestionData" + AudioManager.instance.currSubject + AudioManager.instance.currDifficulty);

        string[] data = dataFile.text.Split(new char[] { '\n' });
        
        for (int i = 1; i < data.Length - 1; i++)
        {
            string[] row = data[i].Split(new char[] { '\t' });
            
            QuestionData questionData = new QuestionData();

            questionData.question = row[0];
            questionData.answer_1 = row[1];
            questionData.answer_2 = row[2];
            questionData.answer_3 = row[3];
            questionData.answer_4 = row[4];
            questionData.correctAnswer = row[5];

            listOfQuestion.Add(questionData);
        }
    }

    public void DisplayQuestion()
    {
        if(currID < listOfQuestion.Count)
        {
            QuestionText.text = listOfQuestion[currID].question;

            AnswerText_1.text = listOfQuestion[currID].answer_1;
            AnswerText_2.text = listOfQuestion[currID].answer_2;
            AnswerText_3.text = listOfQuestion[currID].answer_3;
            AnswerText_4.text = listOfQuestion[currID].answer_4;
        }   
    }

    public bool CheckAnswer(string answer)
    {
        if(currID < listOfQuestion.Count)
        {
            if (listOfQuestion[currID].correctAnswer.Trim() == answer.Trim())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        return false;
    }
}
public class QuestionData
{
    public string question;
    public string answer_1;
    public string answer_2;
    public string answer_3;
    public string answer_4;
    public string correctAnswer;
}
