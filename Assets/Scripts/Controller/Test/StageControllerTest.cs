using UnityEngine;
using System.Collections;

public class StageControllerTest : MonoBehaviour {
	StageController stageController;
	UnitItem[] items;
	string idString = string.Empty;
	int enemyId = 1;
	public float timeElapse = 5.0f;
	float timeCnt = 0.0f;
	
	void Start()
	{
		stageController = new StageController();
		EngineDelegate.instance.SetStageController(stageController);
		stageController.CreateUnit(0, "Player");
	}
	
	void Update()
	{
		timeCnt += Time.deltaTime;
		if (timeCnt >= 0.0f)
		{
			timeCnt -= timeElapse;
			CreateEnemy();
		}
	}
	
	void OnGUI()
	{
		return;
		if (GUILayout.Button("CreatePlayer"))
		{
			stageController.CreateUnit(0, "Player");
			RefreshItems();
		}
		if (GUILayout.Button("CreateEnemy"))
		{
			stageController.CreateUnit(enemyId++, "Enemy");
			RefreshItems();
		}
		GUILayout.BeginHorizontal();
		idString = GUILayout.TextField(idString);
		if (GUILayout.Button ("Kill"))
		{
			try
			{
				int id = int.Parse (idString);
				stageController.KillUnit(id);
				RefreshItems();
			}
			catch(System.Exception ex)
			{
				
			}
		}
		if (GUILayout.Button ("Refresh"))
		{
			RefreshItems();
		}
		GUILayout.EndHorizontal();
		if (items != null)
		{
			for(int i = 0; i < items.Length; i++)
			{
				if (items[i] != null)
					GUILayout.Label(items[i].id.ToString() + " : " + items[i].unit.gameObject.ToString());
			}
		}
	}
	
	void RefreshItems()
	{
		items = stageController.GetItems();
	}
	
	void CreateEnemy()
	{
		float x = (Random.value - 0.5f);
		float y = (Random.value - 0.5f);
		Vector3 pos = new Vector3(x, 0.0f, y).normalized * 50.0f;
		stageController.CreateUnit(enemyId++, "Enemy", pos);
		RefreshItems();
	}
}
