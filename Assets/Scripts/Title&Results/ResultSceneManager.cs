﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultSceneManager : MonoBehaviour
{
	public void OnClick()
	{
		SceneManager.LoadScene("Title" , LoadSceneMode.Additive);
	}
}
