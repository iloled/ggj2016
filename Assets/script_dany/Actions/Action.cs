using UnityEngine;
using System.Collections;

public class Action {

	protected Player p;
	protected string name;

	public Action()
	{
	}

	public Action(Player p)
	{
		this.p = p;
	}

	public void execute()
	{
		Debug.Log ("execute action " + p.name);
		p.actionNumber--;
		behaviour ();
	}

	protected virtual void behaviour()
	{
	}
}
