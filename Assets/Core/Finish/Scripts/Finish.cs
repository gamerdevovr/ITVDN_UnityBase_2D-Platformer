using UnityEngine;

namespace Platformer.Core.Finish
{
    public class Finish : MonoBehaviour
    {
        [SerializeField] private string _objectTag;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.CompareTag(_objectTag))
            {
                return;
            }

            Debug.Log("OnTriggerEnter2D");
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (!collision.CompareTag(_objectTag))
            {
                return;
            }

            Debug.Log("OnTriggerStay2D");
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (!collision.CompareTag(_objectTag))
            {
                return;
            }

            Debug.Log("OnTriggerExit2D");
        }
    }
}
