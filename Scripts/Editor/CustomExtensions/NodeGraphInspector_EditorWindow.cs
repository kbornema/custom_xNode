using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using XNode;
using XNodeEditor;

public class NodeGraphInspector_EditorWindow : EditorWindow
{
    private NodeEditorWindow _nodeEditorWindow;

    public static NodeGraphInspector_EditorWindow Decorate(NodeEditorWindow nodeEditorWindow)
    {   
        var window = GetWindow<NodeGraphInspector_EditorWindow>();
        window.Init(nodeEditorWindow);
        return window;
    }

    private void Init(NodeEditorWindow nodeEditorWindow)
    {
        Debug.Assert(nodeEditorWindow != null);
        _nodeEditorWindow = nodeEditorWindow;
        _nodeEditorWindow.onLateGUI += OnLateGUI;
    }

    private void OnEnable()
    {
        //make sure to update GUI even if GraphEditorWindow is used.
        this.autoRepaintOnSceneChange = true;
    }

    private void OnGUI()
    {           
        var nodes = Selection.GetFiltered<XNode.Node>(SelectionMode.Unfiltered);

        if(nodes.Length == 1)
        {
            var node = NodeEditor.GetEditor(nodes[0], _nodeEditorWindow);

            node.OnHeaderGUI();
            node.OnBodyGUI();
        }

        else if(nodes.Length > 0)
        {
            EditorGUILayout.LabelField("Editing multiple Nodes not supported.");
        }

        else
        {
            EditorGUILayout.LabelField("No Node selected.");
        }

        //make sure to update GraphEditorWindow even if this window is used
        _nodeEditorWindow.Repaint();
    }

    private void OnLateGUI()
    {
        CustomFramework.Editor.EditorWindowDocker.Dock(_nodeEditorWindow, this, CustomFramework.Editor.EditorWindowDocker.DockPosition.Right);
    }
}
