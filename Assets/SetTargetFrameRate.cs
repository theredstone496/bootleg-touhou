using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTargetFrameRate : MonoBehaviour 
{
	public int targetFrameRate = 60;

	private void Update()
	{
		QualitySettings.vSyncCount = 0;
		Application.targetFrameRate = targetFrameRate;
	}
}
