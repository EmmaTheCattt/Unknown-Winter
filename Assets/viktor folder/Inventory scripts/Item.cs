using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SlotTag { None, Head, Chest, Legs, Feet}

[CreateAssetMenu(menuName = "Scriptable Objects/Items")]
public class Item : ScriptableObject
{
    public Sprite sprite;
    public SlotTag itemTag;
}
