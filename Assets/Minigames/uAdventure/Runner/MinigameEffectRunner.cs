using UnityEngine;
using System.Collections;

using uAdventure.Core;
using uAdventure.Runner;

[CustomEffectRunner(typeof(MinigameEffect))]
public class MinigameEffectRunner : CustomEffectRunner {

	MinigameEffect effect;
	
	#region Secuence implementation

	public bool execute ()
	{
		Debug.Log (effect.GetType ());
		return false;
	}

	#endregion

	#region CustomEffectRunner implementation

	public Effect Effect {
		get {
			return effect;
		}
		set {
			effect = value as MinigameEffect;
		}
	}

	#endregion
}
