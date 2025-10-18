using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
	public GameObject pauseMenuRoot;   // assign "PauseMenu"
	public Selectable firstSelected;   // drag "Resume Button" here (optional)

	bool isPaused;

	void Awake()
	{
		if (pauseMenuRoot != null) pauseMenuRoot.SetActive(false);
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (isPaused) Resume();
			else Pause();
		}
	}

	public void Pause()
	{
		isPaused = true;
		pauseMenuRoot.SetActive(true);
		Time.timeScale = 0f;
		AudioListener.pause = true;

		if (firstSelected != null && EventSystem.current != null)
			EventSystem.current.SetSelectedGameObject(firstSelected.gameObject);
	}

	public void Resume()
	{
		isPaused = false;
		pauseMenuRoot.SetActive(false);
		Time.timeScale = 1f;
		AudioListener.pause = false;
	}
}