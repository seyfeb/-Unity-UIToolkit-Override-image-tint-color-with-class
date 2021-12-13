using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class changeTintColor : MonoBehaviour
{
    private bool selected = false;
    
    void OnEnable()
    {
        VisualElement Root = GetComponent<UIDocument>().rootVisualElement;

        var button = Root.Q<Button>(className: "my-button");
        button.clicked += () => ToggleColor(button);
        
        button.RegisterCallback<GeometryChangedEvent>(e =>
        {
            if (!selected)
            {
                button.Q<Image>("icon").tintColor = button.resolvedStyle.color;
            }
        });
    }

    private void ToggleColor(VisualElement element)
    {
        selected = !selected;
        if (selected)
        {
            element.AddToClassList("selected");
        }
        else
        {
            element.RemoveFromClassList("selected");
        }
    }
}
