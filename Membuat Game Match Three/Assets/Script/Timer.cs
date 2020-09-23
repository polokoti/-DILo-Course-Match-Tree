using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
	public float timeStart = 60;
	public Text textBox;
	public bool timerIsRunning = false;

	// Use this for initialization
	void Start()
	{
		timerIsRunning = true;
		textBox.text = timeStart.ToString();
	}

	// Update is called once per frame
	void Update()
	{
		if (timerIsRunning)
		{
			if (timeStart > 0)
			{
				Time.timeScale = 1;
				timeStart -= Time.deltaTime;
				textBox.text = Mathf.Round(timeStart).ToString();
			}

			else
			{
				Time.timeScale = 0;
				timeStart = 0;
				timerIsRunning = false;
			}
		}
	}
}