using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DBContainer
{
    public static Dictionary<characterStyle, CharacterData> characterDB;
   

    public static bool HasCharacter(characterStyle characterStyle)
    {
        if (characterDB == null) return false;
        if (characterDB.ContainsKey(characterStyle) == false) return false;
        return characterDB[characterStyle].HasItem;
    }
    
}
