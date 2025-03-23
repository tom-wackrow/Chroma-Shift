using UnityEngine;

namespace ChromaShift
{
    public class ColourChangerOnCollision : MonoBehaviour
    {
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        [SerializeField]
        public ColourManager.Colour myColour;

        private BoxCollider2D collider;

        private void Awake()
        {
            collider = GetComponent<BoxCollider2D>();

            
        }
        // Update is called once per frame
        void FixedUpdate()
        {
            Collider2D[] hits = Physics2D.OverlapBoxAll(transform.position, collider.size, 0);

            foreach (Collider2D hit in hits)
            {
                
                // Ignore our own collider.
                if (hit == collider)
                    continue;

                ColliderDistance2D colliderDistance = hit.Distance(collider);
                if (!colliderDistance.isOverlapped) continue;

                if (hit.CompareTag("Player"))
                {
                    ColourManager.Instance.VisibleColour = myColour;
                }

                // Ensure that we are still overlapping this collider.
                // The overlap may no longer exist due to another intersected collider
                // pushing us out of this one.
            }
        }
    }
}
