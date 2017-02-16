using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;

public class AddScene : MonoBehaviour {

	[MenuItem("File/Combine Scenes")]
	static void Combine()
	{
		Object[] objects = Selection.objects;

		EditorApplication.SaveCurrentSceneIfUserWantsTo();
		EditorApplication.NewScene();

		foreach (Object item in objects)
		{
			EditorApplication.OpenSceneAdditive(AssetDatabase.GetAssetPath(item));
		}
	}


	[MenuItem("File/Combine Scenes", true)]
	static bool CanCombine()
	{
		if (Selection.objects.Length < 2)
		{
			return false;
		}

		foreach (Object item in Selection.objects)
		{
			if (!Path.GetExtension(AssetDatabase.GetAssetPath(item)).ToLower().Equals(".unity"))
			{
				return false;
			}
		}

		return true;
	}
}
