using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



public class Game : MonoBehaviour {

	private int turn = 1;//LoadDown who's turn
	private int [,] Map = new int[3,3]; // TicTocTae data
	public Texture2D bgp;

	//reset Augr
	//1 stand for "○", 2 stand for "×", 0 stand for ""
	//1 turn to "○", -1 turn for "×"
	void reset() {
		turn = 1;
		for (int i = 0; i < 3; i++) {
			for (int j = 0; j < 3; j++) {
				Map[i, j] = 0;
			}
		}
	}

	// Use this for initialization
	void Start () {
		reset ();
	}

	//checkForGame
	int check(){

		int temp = 0;

		//Horizon
		for (int i = 0; i < 3; i++) {
			if (Map [i, 0] != 0 && Map [i, 1] == Map [i, 0] && Map [i, 2] == Map [i, 1]) {
				return Map [i, 0];
			}
		}

		//Verlical
		for (int j = 0; j < 3; j++) {
			if (Map [0, j] != 0 && Map [1, j] == Map [0, j] && Map [2, j] == Map [1, j]) {
				return Map [0, j];
			}
		}

		//duijiao
		if (Map [1, 1] != 0 &&
			(Map [0, 0] == Map [1, 1] && Map [2, 2] == Map [1, 1]) ||
			(Map [0, 2] == Map [1, 1] && Map [2, 0] == Map [1, 1])) {
			return Map [1, 1];
		}

		//Dead Heat
		for (int i = 0; i < 3; i++) {
			for (int j = 0; j < 3; j++) {
				if (Map [i, j] == 0)
					temp = 1;
			}
		}
		if (temp == 1)
			return 0;
		else
			return 3;

		return 0;
	}

	void OnGUI(){

		GUIStyle Mainstyle = new GUIStyle ();
		GUIStyle fontstyle = new GUIStyle ();
		GUIStyle fontstyle1 = new GUIStyle ();
		GUIStyle fontstyle2 = new GUIStyle ();
		fontstyle.normal.textColor = Color.white;
		fontstyle1.normal.textColor = Color.blue;
		fontstyle2.normal.textColor = Color.red;
		Mainstyle.normal.background = bgp;
		fontstyle.fontSize = 25;
		fontstyle1.fontSize = 48;
		fontstyle2.fontSize = 48;

		GUI.Label (new Rect (0, 0, 1370, 780), "", Mainstyle);

		if(GUI.Button(new Rect(20, 300, 100, 50), "Reset")){ reset(); }

		int result = check(); //"0" stand for Gaming, "1" stand for "○" win, "2"stand for "×" win
				
		if (result == 1) {
			GUI.Label (new Rect (30, 200, 100, 50), "◯ wins!", fontstyle);			
		} else if (result == 2) {
			GUI.Label (new Rect (30, 200, 100, 50), "Ⅹ wins!", fontstyle);		
		} else if (result == 3) {
			GUI.Label (new Rect (25, 200, 100, 50), "A Dead Heat!", fontstyle);
		}

		for (int i = 0; i < 3; i++) {
			for (int j = 0; j < 3; j++) {
				if (Map [i, j] == 1) {
					GUI.Button (new Rect (i * 50 + 180, j * 50 + 120, 50, 50), "◯", fontstyle1);
				}
				if (Map [i, j] == 2) {
					GUI.Button (new Rect (i * 50 + 180, j * 50 + 120, 50, 50), "Ⅹ", fontstyle2);
				}
				if (GUI.Button (new Rect (i * 50 + 180, j * 50 + 120, 50, 50), "")) {
					if (result == 0) {
						if (turn == 1) {
							Map [i, j] = 1;
						} else if (turn == -1) {
							Map [i, j] = 2;
						}
						turn = -turn;
					}
				}
			} 
		}
	}



}
