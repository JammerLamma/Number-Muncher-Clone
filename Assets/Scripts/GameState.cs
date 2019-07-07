using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HA
{
    public class GameState : MonoBehaviour
    {
        [SerializeField] GameObject gameScreen;
        [SerializeField] GameObject levelSelect;
        [SerializeField] Text scoreText;
        [SerializeField] Text winText;
        [SerializeField] int currentScore;
        public bool hasStarted = false;

        private void Awake()
        {
            int gameStatsCound = FindObjectsOfType<GameState>().Length;

            if (gameStatsCound > 1)
            {
                gameObject.SetActive(false);
                Destroy(gameObject);
            }
            else
            {
                DontDestroyOnLoad(gameObject);
            }
        }
        private void Start()
        {
            ChangeUI();
        }

        public void ChangeUI()
        {
            
            if (hasStarted == true)
            {
                winText.enabled = false;
                gameScreen.SetActive(true);
                levelSelect.SetActive(false);
            }
            else
            {
                winText.enabled = false;
                levelSelect.SetActive(true);
                gameScreen.SetActive(false);
            }
        }

        public void AddToScore()
        {
            currentScore += 1;
            scoreText.text = currentScore.ToString();
        }

        public void ResetGame()
        {
            Destroy(gameObject);
        }

        public void Win()
        {
            winText.enabled = true;
        }


    }
}
