using UnityEngine;
using UnityEngine.InputSystem;

public class EnemySelect : MonoBehaviour
{
    [SerializeField] private LayerMask _enemy;
    [SerializeField] private InputActionReference _LeftMouse;
    [SerializeField] private InputActionReference _enemyPosition;
    private Enemy _target;
    public Enemy Target => _target;

    private Camera _cam;
    private void Start()
    {
        _cam = Camera.main;
    }

    private void OnEnable()
    {
        _LeftMouse.action.Enable();
        _enemyPosition.action.Enable();
        _LeftMouse.action.performed += OnEnemySelect;
    }
    private void OnDisable()
    {
        _LeftMouse.action.canceled -= OnEnemySelect;
        _LeftMouse.action.Disable();
        _enemyPosition.action.Disable();
    }
    private void OnEnemySelect(InputAction.CallbackContext context)
    {
        Select();
    }

    private void Select()
    {
        Vector2 screen = _enemyPosition.action.ReadValue<Vector2>();
        Ray ray = _cam.ScreenPointToRay(screen);

        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, Mathf.Infinity, _enemy))
        {
            if (hit.collider.TryGetComponent<Enemy>(out Enemy enemy) )
            {
                _target = enemy;
                Debug.Log("선택");
            }
        }
    }
}
