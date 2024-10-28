using UnityEngine;
using UnityEngine.Playables;
public class PieScript : MonoBehaviour
{
    private Rigidbody2D _body;
    private PolygonCollider2D _collider;
    private bool _isAlive = true;
    [SerializeField] private bool godMode;
    [SerializeField] private int _flyForce;
    [SerializeField] private float _maxSpeed;
    [SerializeField] PlayableDirector _director;
    private void Fly()
    {
        _body.AddForce(Vector3.up * (_flyForce * 100));

        if (_body.velocity.magnitude > _maxSpeed)
        {
            _body.velocity = _body.velocity.normalized * _maxSpeed;
        }
    }

    private void Die()
    {
        if (godMode) return;
        _collider.enabled = false;
        _isAlive = false;
        _director.Play();
    }
    private void Start()
    {
        _body = GetComponent<Rigidbody2D>();
        _collider = GetComponent<PolygonCollider2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isAlive)
        {
            Fly();
        }

        if (transform.position.y is < -6 or > 6) // this is the same as || statement
        {
            Die();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Die();
    }
}
