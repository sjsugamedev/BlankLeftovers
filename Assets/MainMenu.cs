﻿using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour
{
	public Texture backgroundTexture;
	public bool showYesNoPrompt = false;
	GUILayoutOption[] options = new GUILayoutOption[8];
	public float guiPlacementY;
	// Use this for initialization
	void Start ()
	{
	}
	
	void OnGUI ()
	{
		
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), backgroundTexture);
		
		if (GUI.Button (new Rect (Screen.width * .5f, Screen.height * .4f, Screen.width * .5f, Screen.height * .1f), "New Game")) {
			//print ("Clicked Play Game");
			Application.LoadLevel (Application.loadedLevel + 1); //theoretically this should be the first level
		}
		//(new Rect (Screen.width * .5f, Screen.height * .55f, Screen.width * .5f, Screen.height * .1f)
		if (GUILayout.Button ("End Game")) {
			//print ("Clicked End Game");
			Debug.Log ("poop");
			showYesNoPrompt = true;
		}
		if (showYesNoPrompt == true) {
			GUI.Label (new Rect (Screen.width * .25f, Screen.height * .25f, Screen.width * .5f, Screen.height * .1f), "Are You sure you want to quit?");
			if (GUILayout.Button ("Yes",options)) {
				Application.Quit ();
			}
			if (GUI.Button (new Rect (Screen.width * .25f, Screen.height * .25f, Screen.width * .5f, Screen.height * .1f), "NO")) {
				showYesNoPrompt = false;
			}
		}
	}
}