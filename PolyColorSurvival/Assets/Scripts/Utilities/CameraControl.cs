using Assets.Scripts.MainManagers;
using UnityEngine;

namespace Assets.Scripts.Utilities
{
    public class CameraControl : MonoBehaviour
    {
        public Transform target;

        // Update is called once per frame
        void Update () {
            if (StateManager.CurrentState == GameState.Active)
            {
                transform.position = new Vector3(target.position.x, target.position.y, -10f);
            }
        }
    }
}
