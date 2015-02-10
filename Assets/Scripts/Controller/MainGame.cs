using UnityEngine;
using System.Collections;

public class MainGame {
	static MainGame _instance = null;
	public static MainGame instance 
	{
		get
		{
			if (_instance != null)
			{
				_instance = new MainGame();
				_instance.Init();
			}
			return _instance;
		}
	}
	
	public GameController stageController { get; private set; }
	
	void Init()
	{
		stageController = new StageController();
	}
}
