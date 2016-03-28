using UnityEngine;

namespace Assets.Scripts.Utilities
{
    public class CameraControl : MonoBehaviour
    {
        public Transform target;

        // Update is called once per frame
        void Update () {
            transform.position = new Vector3(target.position.x, target.position.y, -10f);
        }
    }
}
