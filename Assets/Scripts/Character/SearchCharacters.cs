using UnityEngine;
using Utils;

namespace Character
{
    [RequireComponent(typeof(CharacterConfig))]
    public class SearchCharacters : MonoBehaviour
    {

        [SerializeField] private SpriteRenderer visual;

        private SearchCharacters[] _searchArray;
        
        private CharacterConfig _characterConfig;
    

        private void Awake()
        {
            _characterConfig = GetComponent<CharacterConfig>();
            visual.color = _characterConfig.GetNormalColor();
        }


        private void LateUpdate()
        {
            CheckForCollision();
        }


        /// <summary>
        /// Checking if any of the objects gets into the visibility zone
        /// </summary>
        private void CheckForCollision()
        {
            bool hasFound = false;

            foreach (var search in _searchArray)
            {
                if (search == this) continue;

                //if the distance between objects is less than the viewing distance, then...
                if (Vector3.Distance(transform.position, search.transform.position) - search.GetObjectRadius() <=
                    _characterConfig.GetViewDistance())
                {
                    Vector3 direction = search.transform.position - transform.position;
                    float angle = UtilsClass.GetAngleFromVector(direction);

                    float characterAngle = transform.eulerAngles.z;

                    //...check whether the object gets into the viewing angle.
                    if ((characterAngle - _characterConfig.GetFov() / 2) <= angle &&
                        (characterAngle + _characterConfig.GetFov() / 2) >= angle)
                    {
                        hasFound = true;
                        break;
                    }
                    else
                    {
                        //If object is in view distance but outside on FOV...
                        float distanceToCenterOfObject =
                            Vector3.Distance(transform.position, search.transform.position);

                        Vector3 extremePointRight = transform.position +
                                                    UtilsClass.GetVectorFromAngle(
                                                        characterAngle - _characterConfig.GetFov() / 2).normalized *
                                                    distanceToCenterOfObject;
                        Vector3 extremePointLeft = transform.position +
                                                   UtilsClass.GetVectorFromAngle(characterAngle + _characterConfig.GetFov() / 2)
                                                       .normalized *
                                                   distanceToCenterOfObject;
                    
                        //...check distance from FOV corners
                        if (Vector3.Distance(extremePointRight, search.transform.position) <= search.GetObjectRadius() ||
                            Vector3.Distance(extremePointLeft, search.transform.position) <= search.GetObjectRadius())
                        {
                            hasFound = true;
                            break;
                        }
                    }
                }
            }
            visual.color = hasFound ? _characterConfig.GetAtFindingColor() : _characterConfig.GetNormalColor();
        }

        /// <summary>
        /// Gets an array of all characters objects in the scene
        /// </summary>
        /// <param name="searchArray"></param>
        public void GetSearchArray(SearchCharacters[] searchArray)
        {
            _searchArray ??= searchArray;
        }

        public float GetObjectRadius()
        {
            return _characterConfig.GetObjectRadius();
        }
    }
}