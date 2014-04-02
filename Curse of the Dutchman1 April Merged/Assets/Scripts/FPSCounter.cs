using UnityEngine;
using System.Collections;

public class FPSCounter : MonoBehaviour {

	public GUIText GuiText;
	float fpsMeasurePeriod = 0.5f;
	int fpsAccumulator = 0;
	float fpsNextPeriod = 0;
	int currentFps;
	string display = "{0} FPS";

	void Start()
	{
		fpsNextPeriod = Time.realtimeSinceStartup + fpsMeasurePeriod;
		GuiText.pixelOffset = new Vector2(20,200);
	}

	void Update()
	{

		// measure average frames per second
		fpsAccumulator++;
		if (Time.realtimeSinceStartup > fpsNextPeriod)
		{
			currentFps = (int)(fpsAccumulator / fpsMeasurePeriod);
			fpsAccumulator = 0;
			fpsNextPeriod += fpsMeasurePeriod;
			GuiText.text = string.Format(display, currentFps);
		}


	}

}
