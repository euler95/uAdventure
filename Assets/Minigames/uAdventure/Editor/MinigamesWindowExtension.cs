using UnityEngine;
using System.Collections;
using uAdventure.Core;
using uAdventure.Editor;
using UnityEditor;
namespace uAdventure.Minigame
{
	[EditorWindowExtension(160, typeof(Minigame))]
	public class MinigamesWindowsExtension : ReorderableListEditorWindowExtension {

		private Minigame selectedMinigame;

		public MinigamesWindowsExtension(Rect rect, GUIStyle style, params GUILayoutOption[] options)
			: base(rect, new GUIContent("Minijuegos"), style, options)
		{
			var content = new GUIContent();


			// Button
			content.image = (Texture2D) Resources.Load("EAdventureData/img/icons/minigame", typeof(Texture2D));
			content.text = "Minijuegos";
			ButtonContent = content;
		}



		public override void Draw (int aID){
			
			if(selectedMinigame==null) {
				EditorGUILayout.LabelField ("Select or create a new Minigame");
				return;
			// Controller.getInstance ().getSelectedChapterDataControl ();
			}
			/*
			EditorGUILayout.BeginVertical ();
			{
				EditorGUI.BeginChangeCheck ();
				selectedMinigame.Content = EditorGUILayout.DelayedTextField ("Content", selectedMinigame.Content);
				//Initialize the first text field		
			}
			EditorGUILayout.EndVertical ();
		*/
		}
			
		protected override void OnElementNameChanged (UnityEditorInternal.ReorderableList r, int index, string newName)
		{
			Controller.getInstance().getSelectedChapterDataControl().getObjects<Minigame>()[index].Id = newName;
		}

		protected override void OnAdd (UnityEditorInternal.ReorderableList r)
		{
			Controller.getInstance().getSelectedChapterDataControl().getObjects<Minigame>().Add(new Minigame("Memorion"));
		}

		protected override void OnUpdateList (UnityEditorInternal.ReorderableList r)
		{
			r.list = Controller.getInstance().getSelectedChapterDataControl().getObjects<Minigame>().ConvertAll(minigame => minigame.Id);
		}

		protected override void OnAddOption (UnityEditorInternal.ReorderableList r, string option)
		{}

		protected override void OnSelect (UnityEditorInternal.ReorderableList r)
		{
			if(r.index == -1)
			{
				selectedMinigame = null;
				return;
			}

			var newSelection = Controller.getInstance().getSelectedChapterDataControl().getObjects<Minigame>()[r.index];
			if(newSelection != null && newSelection != selectedMinigame)
			{
				selectedMinigame = newSelection;
				//RegenerateQR();
			}
		}
		protected override void OnRemove (UnityEditorInternal.ReorderableList r)
		{
			Controller.getInstance().getSelectedChapterDataControl().getObjects<Minigame>().RemoveAt(r.index);
		}
		protected override void OnReorder (UnityEditorInternal.ReorderableList r)
		{
			string idToMove = r.list [r.index] as string;
			var temp = Controller.getInstance ().getSelectedChapterDataControl ().getObjects<Minigame> ();
			Minigame toMove = temp.Find (minigame => minigame.getId () == idToMove);
			temp.Remove (toMove);
			temp.Insert (r.index, toMove);
		}



		protected override void OnButton ()
		{
			selectedMinigame = null;
			reorderableList.index = -1;
		}




		}
}
