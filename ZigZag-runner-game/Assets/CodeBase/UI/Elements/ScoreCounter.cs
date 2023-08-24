using System.Collections;
using TMPro;
using UnityEngine;

namespace CodeBase.UI.Elements
{
    public class ScoreCounter : MonoBehaviour
    {
        public TextMeshProUGUI scoreText;
        public int scoreMultiplier = 1;
        public float updateInterval = 0.01f;

        private int currentScore = 0;

        private void Start()
        {
            StartCoroutine(UpdateScore());
        }

        private IEnumerator UpdateScore()
        {
            WaitForSeconds waitInterval = new WaitForSeconds(updateInterval);

            while (true)
            {
                yield return waitInterval;
                currentScore += scoreMultiplier;
                UpdateScoreText();
            }
        }

        private void UpdateScoreText()
        {
            if (scoreText != null)
            {
                scoreText.text = $"{currentScore}";
            }
        }
    }
}