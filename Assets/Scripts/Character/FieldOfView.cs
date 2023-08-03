using UnityEngine;
using Utils;

namespace Character
{
    [RequireComponent(typeof(CharacterConfig))]
    public class FieldOfView : MonoBehaviour
    {

        [SerializeField] private int sortingOrder = 0;
    
        [SerializeField] private MeshFilter meshFilter;

        private const int RayCount = 10;
        private CharacterConfig _characterConfig;

        private void Awake()
        {
            _characterConfig = GetComponent<CharacterConfig>();
        }

        private void Start()
        {
            GenerateFieldOfViewMesh();
        }

    
        /// <summary>
        /// Create a custom cone mesh representing FOV of character
        /// </summary>
        private void GenerateFieldOfViewMesh()
        {
            Mesh mesh = new Mesh();
            meshFilter.mesh = mesh;

            float angle = _characterConfig.GetFov() / 2;

            float angleIncrease = _characterConfig.GetFov() / RayCount;

            Vector3[] vertices = new Vector3[RayCount + 2];
            Vector2[] uv = new Vector2[vertices.Length];
            int[] triangles = new int[RayCount * 3];

            vertices[0] = Vector3.zero;

            int vertexIndex = 1;
            int triangleIndex = 0;
        
            for (int index = 0; index <= RayCount; index++)
            {
                Vector3 vertex = Vector3.zero + UtilsClass.GetVectorFromAngle(angle) * _characterConfig.GetViewDistance();
                vertices[vertexIndex] = vertex;

                if (index > 0)

                {
                    triangles[triangleIndex] = 0;
                    triangles[triangleIndex + 1] = vertexIndex - 1;
                    triangles[triangleIndex + 2] = vertexIndex;

                    triangleIndex += 3;
                }

                vertexIndex++;
                angle -= angleIncrease;
            }
        
            mesh.vertices = vertices;
            mesh.uv = uv;
            mesh.triangles = triangles;
        
            meshFilter.GetComponent<MeshRenderer>().sortingOrder = sortingOrder;
        }
    }
}