using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class PipeLogic : MonoBehaviour
{
    private Rigidbody2D _body;
    private ObjectPool<PipeLogic> _pipePool;
    [SerializeField] private float _pipeSpeed;

    public void SetPool(ObjectPool<PipeLogic> pool)
    {
        _pipePool = pool;
    }
    
    void Start()
    {
      _body = GetComponent<Rigidbody2D>();  
    }
    
    private void FixedUpdate()
    {
        _body.velocity = new Vector2((-1 * _pipeSpeed), 0);

        if (gameObject.transform.position.x <= -14f)
        {
            _pipePool.Release(this);
        }
    }
}
