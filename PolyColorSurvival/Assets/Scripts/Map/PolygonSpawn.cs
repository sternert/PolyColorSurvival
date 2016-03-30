using UnityEngine;

namespace Assets.Scripts.Map
{
    public class PolygonSpawn : MonoBehaviour
    {
        public GameObject polygon;
        public int numberOfStaticObjects;
        public float mapHalfSize;

        void Awake()
        {
            for (int i = 0; i < numberOfStaticObjects; i++)
            {
                var randomPosition = new Vector3(Random.Range(-mapHalfSize, mapHalfSize), Random.Range(-mapHalfSize, mapHalfSize), -0.1f);
                var quat = Quaternion.identity * Quaternion.Euler(0, 0, Random.Range(0, 360));
                var newObject = Instantiate(polygon, randomPosition, quat) as GameObject;
                var collider = newObject.GetComponent<PolygonCollider2D>();
                collider.CreatePrimitive(Random.Range(3, 10), new Vector2(Random.Range(0.5f, 4f), Random.Range(0.5f, 4f)));
                var colliderToMesh = newObject.GetComponent<ColliderToMesh>();
                colliderToMesh.Meshify();
            }
        }
    }
}
