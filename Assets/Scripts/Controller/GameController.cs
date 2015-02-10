using UnityEngine;
using System.Collections;

public class ControllerMessage
{
	
}

public class GameController {
	GameController parentController;
	
	public void SetParent(GameController parent)
	{
		parentController = parent;
	}
	
	public virtual void Receive(ControllerMessage msg)
	{
		
	}
	
	protected void Send(ControllerMessage msg)
	{
		if (parentController != null)
			Receive(msg);
	}
}
