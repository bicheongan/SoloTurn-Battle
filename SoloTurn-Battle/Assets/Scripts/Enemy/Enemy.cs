using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Animations;

public class Enemy : MonoBehaviour
{
    [SerializeField]private EnemyData _data;
    [SerializeField]private float _currentHp;
    [SerializeField]private float _maxHp;

    private Animator _enemyAnimator;

    public float Hp => _currentHp;
    public float MaxHp => _maxHp;
    public float Attack => _data.Attack;
    public int Speed => _data.Speed;
    public bool IsDead;

    public event Action<float, float> OnChangeHp;
    private void Awake()
    {
        CacheComponents();
    }
    public void Initialize(EnemyData data)
    {
        _data = data;
        _maxHp = _data.HP;
        _currentHp = _data.HP;
        OnChangeHp?.Invoke(_currentHp, _maxHp);
    }
    public void LookPlayer(Transform player)
    {
        transform.LookAt(player);
    }
    public void TakeDamage(float damage)
    {
        if (IsDead) return;
        damage = Mathf.Max(damage * (100f/ (100f+ _data.Defend)), 0f);
        _currentHp = Mathf.Max(_currentHp - (int)damage, 0f);
        OnChangeHp?.Invoke(_currentHp, _maxHp);
        StartCoroutine(HitMotion());
        if (_currentHp <= 0) 
        {
            IsDead = true;
            Debug.Log("적 사망");
            StartCoroutine(DieMotion());
        }
    }

    private IEnumerator DieMotion()
    {
        _enemyAnimator.Play(_data.DieAnim);
        yield return null; //1 프레임 대기 이전상태로 남아있어 기다림이 필요
        float DelayTime = _enemyAnimator.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(DelayTime);
        Destroy(gameObject);
    }
    private IEnumerator HitMotion()
    {
        _enemyAnimator.Play(_data.HitAnim);
        yield return null; //1 프레임 대기 이전상태로 남아있어 기다림이 필요
        float DelayTime = _enemyAnimator.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(DelayTime);
    }
    public IEnumerator AttackMontion()
    {
        _enemyAnimator.Play(_data.AttackAnim);
        yield return null; //1 프레임 대기 이전상태로 남아있어 기다림이 필요
        float DelayTime = _enemyAnimator.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(DelayTime);
    }
    private void CacheComponents()
    {
        _enemyAnimator = GetComponent<Animator>();
    }
}