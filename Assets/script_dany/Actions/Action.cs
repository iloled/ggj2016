using UnityEngine;
using System.Collections;

public class Action {

	protected Player p;
	public string name;

	public Action()
	{
	}

	public Action(Player p)
	{
		this.p = p;
	}

	public void execute()
	{
		behaviour ();
	}

	protected virtual void behaviour()
	{
	}
}
