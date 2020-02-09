using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour 
{
	[Header("	Panels Section")]
	public RectTransform menuPanel;
	public RectTransform gameOverPanel;
	public RectTransform scorePanel;
	public RectTransform controlPanel;
	public RectTransform pausePanel;
	[Header("	Game Counter Section")]
	public Text ScoreText;
	public Text LiveText;
	public AudioClip scoreRangSound;
	public Button menuButton;
	//
	public bool pause = true;
	//
	[Header("	Player Round Option")]
	public int life = 3;
	private int lifeMemory;
	public int score = 0;
	//
	public static GameManager Instance;
	private AudioSource source;

	public GameObject playerPrefab;
	private GameObject playerPrefabMem;

	// Initialization
	private void Awake()
	{
		if (Instance == null) 
		{
			Instance = this; 
		} 
		else
		{
			Destroy(gameObject); 
		}

	}
	// Use this for initialization
	private void Start ()
	{
		lifeMemory = life;
		source = GetComponent<AudioSource>();
		DontDestroyOnLoad(this); 
	}
	// Update is called once per frame
	private void Update () 
	{
		if(!pause)
		{
			IntarfaceUpdate ();
			if(playerPrefabMem == null)
			{
				if(life > 0)
				{
					if(SpawnPlayerPoint.Instace != null)
					playerPrefabMem = (GameObject)Instantiate(playerPrefab, SpawnPlayerPoint.Instace.transform.position, Quaternion.identity);
				}
				else
				{
					GameOver();
				}
			}
		}
	}
	//
	private void IntarfaceUpdate()
	{
		if (ScoreText != null)
			ScoreText.text = score.ToString();
		if (LiveText != null)
			LiveText.text = life.ToString ();

		ScoreEffect();
	}
	//
	public bool IsPause()
	{
		return pause;
	}
	private void ScoreEffect()
	{
		if ((score != 0) && (score % 10) == 0) 
		{
			ScoreText.GetComponent<TextBlinking> ().Blink (1);
			if (!source.isPlaying)
			source.PlayOneShot (scoreRangSound);
		} 
	}
	// Запускаем игру
	public void GameStart()
	{
		pause = true;
		Time.timeScale = 0;
		life = lifeMemory;
		score = 0;
		SceneManager.LoadScene(1);

		menuPanel.gameObject.SetActive(false);
		gameOverPanel.gameObject.SetActive (false);

		menuButton.gameObject.SetActive(false);
		scorePanel.gameObject.SetActive (true);
	}
	// Запускаем уровень
	public void StartLevel()
	{
	    pause = false;
		Time.timeScale = 1;

		menuPanel.gameObject.SetActive(false);
		gameOverPanel.gameObject.SetActive (false);

		scorePanel.gameObject.SetActive (true);
		menuButton.gameObject.SetActive(true);
		controlPanel.gameObject.SetActive (true);
	}
	// Выход из игры
	public void GameExit()
	{
		#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
		#else
			Application.Quit();
		#endif
	}
	//  Поставить на паузу
	public void GamePauseSwitch()
	{
		GamePause(!pause);
	}
	public void GamePause(bool arg)
	{
		pause = arg;
		if(arg == true)
		{
			Time.timeScale = 0;
			menuButton.gameObject.SetActive(false);
			controlPanel.gameObject.SetActive (false);
		}
		else
		{
			Time.timeScale = 1;
			menuButton.gameObject.SetActive(true);
			controlPanel.gameObject.SetActive (true);
		}
		pausePanel.gameObject.SetActive (arg);
	}
	//  Поставить на паузу
	public void GameOver()
	{
		pause = true;
		Time.timeScale = 0;

		scorePanel.gameObject.SetActive (true);
		gameOverPanel.gameObject.SetActive (true);

		menuPanel.gameObject.SetActive (false);
		pausePanel.gameObject.SetActive (false);
		menuButton.gameObject.SetActive (false);
		controlPanel.gameObject.SetActive (false);
	}
	// GameRestart
	public void GameRestart()
	{
		GameStart();
		StartLevel();
	}
	// В главное меню
	public void GameToMain()
	{
		SceneManager.LoadScene(0);

		menuPanel.gameObject.SetActive(true);
		scorePanel.gameObject.SetActive (false);
		gameOverPanel.gameObject.SetActive (false);
		pausePanel.gameObject.SetActive (false);

		menuButton.gameObject.SetActive(false);
		controlPanel.gameObject.SetActive (false);
	}
	public void SetscoreInc(int arg)
	{
		score += arg;
	}
}
