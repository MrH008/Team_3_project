using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Fungus;

public class DeskTrigger : MonoBehaviour
{
    [SerializeField] GameObject monitor;
    [SerializeField] GameObject printer;
    [SerializeField] GameObject projector;
    [SerializeField] GameObject keyboard;
    [SerializeField] GameObject case2;

    [SerializeField] TMP_Text scoreText;
    [SerializeField] Flowchart dialog;  
    [SerializeField] string ExBlock;  
    private int score = 0;

    private void Start()
    {
        UpdateScoreText();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("monitor"))
        {
            monitor.SetActive(true);
            Destroy(other.gameObject);
            IncreaseScore();
        }
        else if (other.CompareTag("printer"))
        {
            printer.SetActive(true);
            Destroy(other.gameObject);
            IncreaseScore();
        }
        else if (other.CompareTag("projector"))
        {
            projector.SetActive(true);
            Destroy(other.gameObject);
            IncreaseScore();
        }
        else if (other.CompareTag("keybosrd"))  
        {
            keyboard.SetActive(true);
            Destroy(other.gameObject);
            IncreaseScore();
        }
        else if (other.CompareTag("case2"))
        {
            case2.SetActive(true);
            Destroy(other.gameObject);
            IncreaseScore();
        }
    }

    private void IncreaseScore()
    {
        score += 1;
        UpdateScoreText();

        if (score >= 5)  
        {
            EndLevel();
        }
    }

    private void EndLevel()
    {
        dialog.ExecuteBlock(ExBlock); 
        Debug.Log("Level Finished!");
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }
}

