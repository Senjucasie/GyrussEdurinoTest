using UnityEngine;

public class WorldCenter : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        //Debug.Log($"Worlcenter hit: {collider.name}");
        IInteractableBullet interactableBullet = collider.GetComponent<IInteractableBullet>();
        interactableBullet?.HideBullet();
    }
}
