using UnityEngine;
using System.Collections;

public class Pivot : MonoBehaviour {
    [SerializeField]
    private float radius=0.1f;
    [SerializeField]
    private Color color = Color.red;
#if UNITY_EDITOR
    void OnDrawGizmos()
    {
        Gizmos.color = color;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
#endif
}
