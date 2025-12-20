using UnityEngine;

[RequireComponent ( typeof ( TrailRenderer ), typeof ( BoxCollider ) ) ]
public class ClickAndSwipe : MonoBehaviour
{
    private GameManager _gameManager;
    private Vector3 _mousePos;
    private Camera _mainCamera;
    private TrailRenderer _trail;
    private BoxCollider _col;

    private bool _isSwiping = false;

    void Awake ()
    {
        _gameManager = GameObject.Find ("Game Manager" ).GetComponent < GameManager > ();
        _mainCamera = Camera.main;
        _trail= GetComponent < TrailRenderer > ();
        _col = GetComponent < BoxCollider > ();
        _col.enabled = false;
        _trail.enabled = false;
    }

    void Update ()
    {
        if ( !_gameManager.isGameOver )
        {
            if ( Input.GetMouseButtonDown ( 0 ) )
            {
                _isSwiping = true;
                UpdateComponents ();
            }
            if ( Input.GetMouseButtonUp ( 0 ) )
            {
                _isSwiping = false;
                UpdateComponents ();
            }
            if ( _isSwiping )
            {
                UpdateMousePosition ();
            }
        }
        else
        {
            _isSwiping = false;
            UpdateComponents ();
        }
    }

    void OnCollisionEnter ( Collision col )
    {
        if ( ! _gameManager.isGameOver && ! _gameManager.isGamePaused )
        {
            Target target = col.gameObject.GetComponent < Target > ();
            if ( col.gameObject.CompareTag ( "Good" ) )
            {
                _gameManager.GameOver ();
                target.Death ( 0 );
            }
            else
            {
                target.Death ( target.scoreValue );
            }
        }
    }

    void UpdateMousePosition ()
    {
        _mousePos = _mainCamera.ScreenToWorldPoint ( new Vector3 ( Input.mousePosition.x,
                                                                   Input.mousePosition.y,
                                                                   10f ) );
        transform.position = _mousePos;
    }

    void UpdateComponents ()
    {
        _trail.enabled = _isSwiping;
        _col.enabled = _isSwiping;
    }
}
