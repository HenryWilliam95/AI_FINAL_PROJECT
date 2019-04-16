using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusSceneView : MonoBehaviour
{
	void Update ()
    {
#if UNITY_EDITOR
UnityEditor.SceneView.FocusWindowIfItsOpen(typeof(UnityEditor.SceneView));
#endif
    }

}
