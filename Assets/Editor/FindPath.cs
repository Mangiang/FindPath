using UnityEngine;
using System.Collections;
using UnityEditor;


public static class FindPath
{
	static string path = "";
	static Object[] obj = new Object[1];

	// Add the item to the right click
	[MenuItem("GameObject/FindPath", false, 0)]
	static void Init()
	{
		obj[0] = Selection.objects[0];

		// Ping the object in the hierarchy view
		EditorGUIUtility.PingObject(obj[0]);

		Transform tmp = ((GameObject)obj[0]).transform;
		path = tmp.name;
		tmp = tmp.parent;

		// Add to the "path" upward to the root
		while (tmp != null)
		{
			path = tmp.name + "/" + path;
			tmp = tmp.parent;
		}

		// Copy the path to the clipboard
		EditorGUIUtility.systemCopyBuffer = path;
	}

}


