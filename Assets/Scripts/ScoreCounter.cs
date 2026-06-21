using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
	public int score = 0;
	public TextMeshProUGUI scoreText;
	public float tickInterval = 1f;

	private float timer;
	private bool running = true;

	private void Start()
	{
		timer = 0f;
		UpdateText();
	}

	private void Update()
	{
		if (!running)
			return;

		timer += Time.deltaTime;

		if (timer >= tickInterval)
		{
			int ticks = Mathf.FloorToInt(timer / tickInterval);
			timer -= ticks * tickInterval;
			score += ticks;
			UpdateText();
		}
	}

	public void ResetScore()
	{
		score = 0;
		timer = 0f;
		UpdateText();
	}

	public void SetRunning(bool isRunning)
	{
		running = isRunning;
	}

	private void UpdateText()
	{
		if (scoreText != null)
			scoreText.text = "Score: " + score.ToString();
	}
}
