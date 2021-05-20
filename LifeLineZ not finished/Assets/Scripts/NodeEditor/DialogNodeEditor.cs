using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using XNode;
using XNodeEditor;

namespace Tutorials.DialogSystem.Scripts.Editor
{
    [CustomNodeEditor(typeof(DialogInforamtion))]
    public class DialogNodeEditor : NodeEditor
    {
        public override void OnBodyGUI()
        {
            serializedObject.Update();

            var segment = serializedObject.targetObject as DialogInforamtion;

            NodeEditorGUILayout.PortField(segment.GetPort("input"));
            
            GUILayout.Label("Dialog Text");
            segment.MessageArray = GUILayout.TextArea(segment.MessageArray, new GUILayoutOption[]
            {
                GUILayout.MinHeight(EditorStyles.label.CalcHeight(new GUIContent(segment.MessageArray),60)),
              
                
            });
            
            NodeEditorGUILayout.DynamicPortList(
                "Answers", // field name
                typeof(string), // field type
                serializedObject, // serializable object
                NodePort.IO.Input, // new port i/o
                Node.ConnectionType.Override, // new port connection type
                Node.TypeConstraint.None,
                OnCreateReorderableList); // onCreate override. This is where the magic 
            
            
            foreach (XNode.NodePort dynamicPort in target.DynamicPorts) {
                if (NodeEditorGUILayout.IsDynamicPortListPort(dynamicPort)) continue;
                NodeEditorGUILayout.PortField(dynamicPort);
            }

            serializedObject.ApplyModifiedProperties();
        }

        void OnCreateReorderableList(ReorderableList list)
        {
            list.elementHeightCallback = (int index) =>
            {
                var segment = serializedObject.FindProperty("Answers").GetArrayElementAtIndex(index).FindPropertyRelative("actions");
                return 60 + EditorGUI.GetPropertyHeight(segment);
            };
            
            // Override drawHeaderCallback to display node's name instead
            list.drawElementCallback = (Rect rect, int index, bool isActive, bool isFocused) =>
            {
                var segment = serializedObject.targetObject as DialogInforamtion;

                NodePort port = segment.GetPort( "Answers " + index);
                Rect r1 = rect;
                r1.height = 60;
                Rect r2 = rect;
                r2.y += 60;
                r2.height -= 60;
                segment.Answers[index].text = GUI.TextArea(r1, segment.Answers[index].text);
                EditorGUI.PropertyField(r2, serializedObject.FindProperty("Answers").GetArrayElementAtIndex(index).FindPropertyRelative("actions"));

                if (port != null) {
                    Vector2 pos = rect.position + (port.IsOutput?new Vector2(rect.width + 6, 0) : new Vector2(-36, 0));
                    NodeEditorGUILayout.PortField(pos, port);
                }
            };
        }
    }
}