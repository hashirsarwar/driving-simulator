using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text player1ScoreTag;
    public TMP_Text player2ScoreTag;

    private int player1Score;
    private int player2Score;


   public GameObject Player1MiniTag;

    public GameObject Player2MiniTag;

    void Start()
    {
        player1ScoreTag.text = "Score: 0";
        player2ScoreTag.text = "Score: 0";

        player1Score = 0;
        player2Score = 0;
    }

    public void AddScore(int scoreObtained, int player)
    {
        if (player == 1)
        {
            player1Score += scoreObtained;
            player1ScoreTag.text = "Score: " + player1Score;
            if(scoreObtained>0)
            {
                Player1MiniTag.GetComponent<TMP_Text>().color = Color.green;
            }
            else
            {
                Player1MiniTag.GetComponent<TMP_Text>().color = Color.red;
            }
            Player1MiniTag.GetComponent<TMP_Text>().text = scoreObtained.ToString();
            Player1MiniTag.SetActive(true);
            StartCoroutine(DisableMiniTag(player));
        }

        else
        {
            player2Score += scoreObtained;
            player2ScoreTag.text = "Score: " + player2Score;

            if(scoreObtained>0)
            {
                Player2MiniTag.GetComponent<TMP_Text>().color = Color.green;
            }
            else
            {
                Player2MiniTag.GetComponent<TMP_Text>().color = Color.red;
            }
            Player1MiniTag.GetComponent<TMP_Text>().text=scoreObtained.ToString();
            Player2MiniTag.SetActive(true);

            StartCoroutine(DisableMiniTag(player));
        }
    }

    IEnumerator DisableMiniTag(int player)
    {
        
        yield return new WaitForSeconds(0.5f);
        if (player==1)
        {
        Player1MiniTag.SetActive(false);
        }
        else
        {
            Player2MiniTag.SetActive(false);
        }

    }
}
