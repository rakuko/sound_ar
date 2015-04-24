using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	string mainMenuSceneName;
	Font pauseMenuFont;
	private bool pauseEnabled = false;
	int stop_index = 0;

	int address_list_size;
	string[] bus_stops;
	bool to_pratt = true;


	public GUIStyle MenuStyle;
	public GUISkin MenuSkin;

	public Vector2 scrollPosition = Vector2.zero;

	/*
	private bool showList = false;
	private int listEntry = 0;
	private GUIContent[] list;
	private GUIStyle listStyle;
	private bool picked = false;


	// Use this for initialization
	void Start () {
		list = new GUIContent[3];
		list [0] = new GUIContent("Jay St/Myrtle Plz");
		list [1] = new GUIContent("Tillary St/Jay St");
		list [2] = new GUIContent("Myrtle Av/Fleet Pl");
	}
	
	// Update is called once per frame
	void OnGUI () {
		if (Popup.List (Rect (500, 800, 500, 800), showList, listEntry, new GUIContent("Destination"), list, listStyle)) {
			picked = true;
		}
	}*/



	void Start(){

		bus_stops = new string[12]; //<---- change this number if you want to add more than 10 bus stops
		bus_stops [0] = "Jay St/Myrtle Plz";
		bus_stops [1] = "Tillary St/Jay St";
		bus_stops [2] = "Myrtle Av/Fleet Pl";
		bus_stops [3] = "Myrtle Av/Ashland";
		bus_stops [4] = "Myrtle Av/St Edwards";
		bus_stops [5] = "Myrtle Av/N Portland";
		bus_stops [6] = "Myrtle Av/Carlton";
		bus_stops [7] = "Myrtle Av/Vanderbilt";
		bus_stops [8] = "Myrtle Av/Clinton";
		bus_stops [9] = "Myrtle Av/Washington";
		bus_stops [10] = "Myrtle Av/Ryerson";
		bus_stops [11] = "Myrtle Av/Steuben";



		pauseEnabled = false;
		Time.timeScale = 1;
		AudioListener.volume = 1;
		Screen.showCursor = true;
	
	}
	
	void Update(){
	}
	
	private bool showGraphicsDropDown = false;
	
	void OnGUI(){
		
		//GUI.skin.box.font = pauseMenuFont;
		GUI.skin = MenuSkin;

		if (GUI.Button (new Rect (50, 50, 300, 100), "Streets")) {
			
			if (showGraphicsDropDown == false) {
					showGraphicsDropDown = true;
			} else {
					showGraphicsDropDown = false;
			}
		}
		//Create the Graphics settings buttons, these won't show automatically, they will be called when
		//the user clicks on the "Change Graphics Quality" Button, and then dissapear when they click
		//on it again....
		if (showGraphicsDropDown) {
			scrollPosition = GUI.BeginScrollView(new Rect(350,50,820,Screen.height - 450), scrollPosition, new Rect(0,0,800,1200));
			/*
			if(GUI.Button(new Rect(350,50 ,800, 100), bus_stops [0])){
				stop_index = 0;
			}
			if(GUI.Button(new Rect(350,150,800, 100), bus_stops [1])){
				stop_index = 1;
			}
			if(GUI.Button(new Rect(350,250,800, 100), bus_stops [2])){
				stop_index = 2;
			}
			*/
			if(GUI.Button(new Rect(0, 0 , 800, 100), bus_stops [0])){
				stop_index = 0;
			}
			if(GUI.Button(new Rect(0, 100, 800, 100), bus_stops [1])){
				stop_index = 1;
			}
			if(GUI.Button(new Rect(0, 200, 800, 100), bus_stops [2])){
				stop_index = 2;
			}
			if(GUI.Button(new Rect(0, 300, 800, 100), bus_stops [0])){
				stop_index = 3;
			}
			if(GUI.Button(new Rect(0, 400, 800, 100), bus_stops [1])){
				stop_index = 4;
			}
			if(GUI.Button(new Rect(0, 500, 800, 100), bus_stops [2])){
				stop_index = 5;
			}
			if(GUI.Button(new Rect(0, 600, 800, 100), bus_stops [0])){
				stop_index = 6;
			}
			if(GUI.Button(new Rect(0, 700, 800, 100), bus_stops [1])){
				stop_index = 7;
			}
			if(GUI.Button(new Rect(0, 800, 800, 100), bus_stops [2])){
				stop_index = 8;
			}
			if(GUI.Button(new Rect(0, 900, 800, 100), bus_stops [0])){
				stop_index = 9;
			}
			if(GUI.Button(new Rect(0, 1000, 800, 100), bus_stops [1])){
				stop_index = 10;
			}
			if(GUI.Button(new Rect(0, 1100, 800, 100), bus_stops [2])){
				stop_index = 11;
			}
			GUI.EndScrollView();
		}

		if (GUI.Button(new Rect(50,Screen.height-300,300, 100), "To NYU")){
			to_pratt = false;
		}
		if (GUI.Button(new Rect(Screen.width - 300,Screen.height-300,300, 100), "To Pratt")){
			to_pratt = true;
		}

		if(GUI.Button(new Rect(50,Screen.height - 100,300, 100), "Submit")){
			Manager.current_index = stop_index;
			Manager.Pratt = to_pratt;
			Application.LoadLevel("map");
		}
			
	}

}
