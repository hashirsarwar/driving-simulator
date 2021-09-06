using System.Collections;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text player1ScoreTag;
    public TMP_Text player2ScoreTag;
    private int player1Score = 0;
    private int player2Score = 0;
    public GameObject player1MiniTag;
    public GameObject player2MiniTag;
    public GameObject player1;
    public GameObject player2;

    void Start()
    {
        StartCoroutine(IncrementLeadingPlayerScore());
    }

    public void AddScore(int scoreObtained, int player)
    {
        if (player == 1)
        {
            player1Score += scoreObtained;
            DisplayScoreOnTags(player1Score, scoreObtained, player1ScoreTag, player1MiniTag);
        }

        else
        {
            player2Score += scoreObtained;
            DisplayScoreOnTags(player2Score, scoreObtained, player2ScoreTag, player2MiniTag);
        }
    }

    void DisplayScoreOnTags(int score, int scoreObtained, TMP_Text mainTag, GameObject miniTag)
    {
        mainTag.text = "Score: " + score;

        if (scoreObtained > 0)
        {
            miniTag.GetComponent<TMP_Text>().color = Color.green;
            miniTag.GetComponent<TMP_Text>().text = "+ " + scoreObtained.ToString();
        }
        else
        {
            miniTag.GetComponent<TMP_Text>().color = Color.red;
            miniTag.GetComponent<TMP_Text>().text = scoreObtained.ToString();
        }
        miniTag.SetActive(true);
        StartCoroutine(DisableMiniTag(miniTag));
    }

    IEnumerator DisableMiniTag(GameObject miniTag)
    {
        yield return new WaitForSeconds(0.5f);
        miniTag.SetActive(false);
    }

    IEnumerator IncrementLeadingPlayerScore()
    {
        while (true)
        {
            yield return new WaitForSeconds(5);
            if (player1.transform.position.z > player2.transform.position.z)
            {
                AddScore(50, 1);
                AddScore(-50, 2);
            }
            else
            {
                AddScore(50, 2);
                AddScore(-50, 1);
            }
        }
    }
}
