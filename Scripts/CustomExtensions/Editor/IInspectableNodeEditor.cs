using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A <see cref="XNodeEditor.NodeEditor"/> with this interface will be drawn differently when inspected via <see cref="NodeGraphInspector_EditorWindow"/>
/// </summary>
public interface IInspectableNodeEditor
{
    void InspectableNodeGUI();
}
