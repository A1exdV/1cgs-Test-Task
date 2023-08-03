using Character;
using UnityEngine;

public class CharacterObjectsFinder : MonoBehaviour
{
    private SearchCharacters[] _searchArray;

    private void Awake()
    {
        _searchArray = FindObjectsOfType<SearchCharacters>();
        
        Debug.Log($"{_searchArray.Length} character objects found.");
        
        //Send all characters array of other objects
        foreach (var search in _searchArray)
        {
            search.GetSearchArray((SearchCharacters[])_searchArray.Clone());
        }
    }
}
