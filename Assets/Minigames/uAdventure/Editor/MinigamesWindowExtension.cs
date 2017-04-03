using UnityEngine;
using System.Collections;
using uAdventure.Core;
using uAdventure.Editor;
using UnityEditor;

[EditorWindowExtension(160, typeof(MinigameEffect))]
public class MinigamesWindowsExtension : DefaultButtonMenuEditorWindowExtension {

	public MinigamesWindowsExtension(Rect rect, GUIStyle style, params GUILayoutOption[] options)
		: base(rect, new GUIContent("Minijuegos"), style, options)
	{
		var content = new GUIContent();

		// Button
		content.image = (Texture2D) Resources.Load("EAdventureData/img/icons/minigame", typeof(Texture2D));
		content.text = "Minijuegos";
		ButtonContent = content;
	}

	#region implemented abstract members of BaseWindow

	public override void Draw (int aID)
	{
		EditorGUILayout.LabelField ("Hola minijuegos");
		// Controller.getInstance ().getSelectedChapterDataControl ();
	}

	#endregion

	#region implemented abstract members of ButtonMenuEditorWindowExtension

	protected override void OnButton ()
	{
	}

	#endregion




}
