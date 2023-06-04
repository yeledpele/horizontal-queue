using UnityEditor;
using UnityEngine;

namespace QueueGame.MenuItems
{
    public static class ResetSelectedTransform
    {
        [MenuItem("QueueGame/Editor/Reset Selected Transforms")]
        public static void Perform()
        {
            Undo.RecordObjects(Selection.transforms, "ResetSelectedTransforms");
            foreach (var selected in Selection.transforms)
            {
                selected.localPosition = Vector3.zero;
                selected.localRotation = Quaternion.identity;
                selected.localScale = Vector3.one;
            }
        }
    }
}