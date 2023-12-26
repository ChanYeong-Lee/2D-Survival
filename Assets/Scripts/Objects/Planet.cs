using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Planet : MonoBehaviour
{
    [HideInInspector] public float distance;
    [HideInInspector] public float damage;
    [HideInInspector] public float speed;

    private Transform pivot;

    private void Start()
    {
        pivot = GameManager.Instance.player.transform;
    }

    public void Shot()
    {
        PoolManager.Instance.RemoveObject(gameObject, PoolType.Planet, 10f);
    }

    private void OnEnable()
    {
        angle = 0;
    }

    private void OnDisable()
    {
        transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
    }

    private float angle;
    private void FixedUpdate()
    {
        transform.Rotate(new Vector3(0, 0, 2 * Time.fixedDeltaTime));
        angle += Time.fixedDeltaTime * speed;
        float x = distance * Mathf.Cos(angle);
        float y = distance * Mathf.Sin(angle);
        transform.position = new Vector2(pivot.position.x + x, pivot.position.y + y);
        if (angle >= 2 * Mathf.PI) angle = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy target))
        {
            target.TakeDamage(this.damage);
            PoolManager.Instance.RemoveObject(gameObject, PoolType.Planet);
        }
    }
}
