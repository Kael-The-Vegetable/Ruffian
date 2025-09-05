
#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

[CustomPropertyDrawer(typeof(CardGames.Card))]
public class CardEditor : PropertyDrawer
{
	public VisualTreeAsset vt;

	public override VisualElement CreatePropertyGUI(SerializedProperty property)
	{
		VisualElement root = new VisualElement();
		vt.CloneTree(root);
		root.Q<Label>("Name").text = property.displayName;
		return root;
	}
}
#endif