using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
	public GameObject hazard;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	public int waveCount;

	public GUIText scoreText;
	public GUIText restartText;
	public GUIText gameOverText;
	public GUIText waveText;
	private int score;

	private bool gameOver;
	private bool restart;

	void Start()
	{
		gameOver = false;
		restart = false;
		gameOverText.text = "";
		restartText.text = "";
		waveText.text = "";
		waveCount = 1;
		score = 0;
		UpdateScore ();
		StartCoroutine ( ShowWaveCount(waveCount));
		StartCoroutine (SpawnWaves ());
	}

	void Update()
	{
		if (restart) {
			if (Input.GetKeyDown (KeyCode.R))
			{
				Application.LoadLevel(Application.loadedLevel);
			}
		}
	}
	IEnumerator SpawnWaves()
	{
		yield return new WaitForSeconds (startWait);

		while (true) {
			for (int i = 0; i < hazardCount; i++) {
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			waveCount++;
			yield return new WaitForSeconds(waveWait);
			StartCoroutine (ShowWaveCount(waveCount));
			hazardCount+=5;
			spawnWait-=0.05f;

			if (gameOver)
			{
				restartText.text = "按'R'键重新开始";
				restart = true;
				break;
			}
		}

	}

	IEnumerator ShowWaveCount(int count)
	{
		if (gameOver) {
			waveText.text = "";
		} else {
			waveText.text = "'第" + count + "波'陨石";
			yield return new WaitForSeconds (1.5f);
		}
		waveText.text = "";
	}

	public void AddScore(int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}

	void UpdateScore()
	{
		scoreText.text = "目前得分：" + score;
	}

	public void GameOver()
	{
		gameOverText.text = "你怎么这么水?";
		gameOver = true;
	}
}
