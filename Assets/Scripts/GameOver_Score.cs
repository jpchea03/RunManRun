using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GamerOver_Score : MonoBehaviour
{

    public TMP_Text finalScore;
    private int final_score;

    //Start is called before the first frame update
    void Start()
    {
        final_score = UpdateScore.GetScore();
        finalScore.text = "Final Score: " + final_score.ToString();

        UpdateScore.ChangeScore(0);
    }

}
