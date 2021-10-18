using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isPlaying = true;

    public GameObject endGameCanvas;
    public TextMeshProUGUI timerTxt;
    private float _timer;

    private void OnGUI()
    {
        SortSprites();
    }

    // Start is called before the first frame update
    void Start()
    {
        endGameCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        SortSprites();
        _timer += Time.deltaTime;
    }

    public void SortSprites()
    {
        foreach (var sprite in FindObjectsOfType<SpriteRenderer>())
        {
            if (sprite.sortingLayerName.Equals("Middleground"))
            {
                sprite.sortingOrder = (int)(1000f * -sprite.transform.position.y);
            }
        }
    }

    public void OnExit()
    {
        SceneManager.LoadScene("Menu");
    }

    public void OnLose()
    {
        isPlaying = false;
        timerTxt.text = _timer.ToString();
        timerTxt.text = timerTxt.text.Substring(0, timerTxt.text.IndexOf('.')) +
                        timerTxt.text.Substring(timerTxt.text.IndexOf('.'), 3) + 's';
        endGameCanvas.SetActive(true);
    }

    public void OnReplay()
    {
        SceneManager.LoadScene("Game");
    }
}
