using UnityEngine;
using Random = UnityEngine.Random;

namespace Character
{
    [RequireComponent(typeof(CharacterConfig))]
    public class CharacterMovement : MonoBehaviour
    {
        private BorderCheck _borderCheck;
        private CharacterConfig _characterConfig;

        private void Awake()
        {
            _characterConfig = GetComponent<CharacterConfig>();
            _borderCheck = new BorderCheck(_characterConfig.GetObjectRadius());
        }

        private void Start()
        {
            RotateCharacter();
        }

        private void Update()
        {
            MoveCharacter();
        }

        /// <summary>
        /// Moving an object along the view axis
        /// </summary>
        private void MoveCharacter()
        {
            var nextPosition = transform.position + transform.right * (_characterConfig.GetMovementSpeed() * Time.deltaTime);
        
            //if on next frame object will collide with borders... 
            if (!_borderCheck.CheckForBordersCollision(nextPosition))
            {
                do
                {
                    //...change object rotation until no collision on next frame
                    RotateCharacter();
                    nextPosition = transform.position + transform.right * (_characterConfig.GetMovementSpeed() * Time.deltaTime);
                } while (!_borderCheck.CheckForBordersCollision(nextPosition));
            }
        
            transform.position = nextPosition;
        }

        /// <summary>
        /// Rotate an object by a random angle
        /// </summary>
        public void RotateCharacter()
        {
            transform.eulerAngles = new Vector3(0, 0, Random.Range(0, 360));
        }

        private void OnDisable()
        {
            _borderCheck.OnDisable();
        }
    }
}
