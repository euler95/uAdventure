using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using uAdventure.Core;
using uAdventure.Editor;

[DOMWriter(typeof(MinigameEffect))]
public class MinigameEffectWriter : ParametrizedDOMWriter {
	#region implemented abstract members of ParametrizedDOMWriter

	protected override string GetElementNameFor (object target)
	{
		return "launch-minigame";
	}

	protected override void FillNode (System.Xml.XmlNode node, object target, params IDOMWriterParam[] options)
	{
		
	}

	#endregion


}
