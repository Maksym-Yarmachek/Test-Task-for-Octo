using UnityEngine;
using UnityEngine.UI;
using Naninovel;
using System.Collections;
using System.Collections.Generic;
using System;

public class ImageSwaper : MonoBehaviour
{

    public Image image;
    public CustomVariableTrigger trigger;
    
    
    public Dictionary<int, Sprite> sprites = new Dictionary<int, Sprite>();
    public ImageSwaperElement[] swaperElements;


    private void Awake()
    {
        if (image == null) Debug.LogError($"Image component is not assigned to {this.gameObject.name} in the inspector.");
        if (trigger == null) Debug.LogError($"CustomVariableTrigger component is not assigned to {this.gameObject.name} in the inspector.");
    }

    private void Start()
    {
        foreach (ImageSwaperElement item in swaperElements)
        {
            sprites.Add(item.id, item.sprite);
        }
    }

    public void SwapTheImage()
    {
        int triggerValue = int.Parse(trigger.CustomVariableValue);
        if (triggerValue == 0)
            image.enabled = false;
        else
        {
            image.enabled = true;
            image.sprite = sprites[triggerValue];
        }
    }
}

[Serializable]
public class ImageSwaperElement
{
    public int id;
    public Sprite sprite;
}
