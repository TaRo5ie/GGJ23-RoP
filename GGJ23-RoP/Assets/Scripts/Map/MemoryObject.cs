using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MemoryObject", menuName = "ScriptableObjects/MemoryObject", order = 1)]
public class MemoryObject : ScriptableObject
{
    public enum LifeState
    {None, Child, Young, MiddleAged, Old}

    [HideInInspector]
    public int choiceNumber;
    public int objectID;
    public LifeState lifeState;
    public Sprite memoryPreview;
    
}
