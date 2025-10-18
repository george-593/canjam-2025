using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject target;
    private bool isPaused = false;

    // Update is called once per frame
    private void Update()
    {
        // Toggle the target when the escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
			TogglePause();
        }
    }

	// Unpause the game since it might already be paused
	private void Start()
	{
		isPaused = false;
		Time.timeScale = 1;
		if (target) target.SetActive(false);
	}

	public void TogglePause()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0 : 1;
        target.SetActive(!target.activeSelf);
    }
}