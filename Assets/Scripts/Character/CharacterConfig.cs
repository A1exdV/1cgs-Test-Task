using UnityEngine;

namespace Character
{
    public class CharacterConfig : MonoBehaviour
    {
        [SerializeField] private float movementSpeed,objectRadius;
        [Space]
        [SerializeField,Range(0,360)] private float fov = 90f;
        [SerializeField,Range(0.01f,5)] private float viewDistance = 2;
        [Space]
        [SerializeField] private Color normal;
        [SerializeField] private Color atFinding;

        public float GetMovementSpeed()
        {
            return movementSpeed;
        }

        public float GetObjectRadius()
        {
            return objectRadius;
        }

        public float GetFov()
        {
            return fov;
        }

        public float GetViewDistance()
        {
            return viewDistance;
        }

        public Color GetNormalColor()
        {
            return normal;
        }

        public Color GetAtFindingColor()
        {
            return atFinding;
        }
    }
}
