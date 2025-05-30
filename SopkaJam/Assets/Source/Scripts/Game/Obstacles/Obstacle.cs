using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private float _speed;
   
   public void Initialize(float speed)
    {
        _speed = speed;
    }

    private void Update()
    {
        transform.Translate(Vector3.left *_speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent<DestroyObstaclesTrigger>(out DestroyObstaclesTrigger obstacleTrigger))
        {
            Destroy(this.gameObject);
        }
    }
}
