using UnityEngine;

public class ShipComponent : MonoBehaviour
{
    public SpriteRenderer Image;
    public Transform[] ShootPoints;
    public float ShootTimer;
    public float ShootDelay;

    public void Update()
    {
        if(ShootTimer<=0) return;
        
        ShootTimer -= Time.deltaTime;
    }
}
