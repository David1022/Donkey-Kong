using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class FinalManager : MonoBehaviour
{
    static OutputData outputData;

    public Text timeText;
    public Text scoreText;
    public Text winnerText;

    void Start()
    {
        ReadWinner();
    }

    public void ReadWinner()
    {
        AssetDatabase.ImportAsset(SaveLoad.OUTPUT_PATH);

        TextAsset data = Resources.Load<TextAsset>(SaveLoad.FINAL_INPUT_PATH);
        outputData = JsonUtility.FromJson<OutputData>(data.ToString());

        string time = "";
        string score = "";
        bool win = false;

        if ((outputData.time != "") && (outputData.score != ""))
        {
            time = outputData.time + " s";
            score = outputData.score + " $";
            win = outputData.win;
        }
        timeText.text = time;
        scoreText.text = score;
        if (win)
        {
            winnerText.text = "YOU WIN";
            winnerText.color = Color.green;
        }
        else
        {
            winnerText.text = "YOU LOSE";
            winnerText.color = Color.red;
        }
    }
}
