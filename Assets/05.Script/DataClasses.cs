using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public struct CharacterData
{
    public string Name;
    public bool HasItem;

    public CharacterData(string Name,bool HasItem)
    {
        this.Name = Name;
        this.HasItem = HasItem;
    }    

}
