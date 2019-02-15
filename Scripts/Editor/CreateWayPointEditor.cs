#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
namespace ShooterGame.Editor
{
	[CustomEditor(typeof(CreateWayPoint))]
	public class CreateWayPointEditor : UnityEditor.Editor
	{
		private void OnSceneGUI()
		{
			CreateWayPoint testTarget = (CreateWayPoint)target;
			if (Event.current.button == 0 && Event.current.type == EventType.MouseDown)
			{
				Ray ray = Camera.current.ScreenPointToRay(new Vector3(Event.current.mousePosition.x,
					SceneView.currentDrawingSceneView.camera.pixelHeight - Event.current.mousePosition.y));

				if (Physics.Raycast(ray, out var hit))
				{
					testTarget.InstantiateObj(hit.point);
				}
			}

			Selection.activeGameObject = FindObjectOfType<CreateWayPoint>().gameObject;
		}
	}
#endif
}