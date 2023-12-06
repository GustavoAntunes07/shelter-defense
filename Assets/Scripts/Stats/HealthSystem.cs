using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthSystem : MonoBehaviour
{
    [SerializeField, Min(0)] float hp;
    [SerializeField, Min(0)] float maxHp = 100f;
    [SerializeField, Min(0)] float regenerateHpPerSec = 2f;
    [SerializeField, Min(0)] float regenerateHpDelay = 10f;

    [Space(8), Header("Events")]
    public FloatEvent OnSendNormalizedHp;
    public FloatEvent OnSendHp;
    public UnityEvent OnHpEmpty;
    public FloatEvent OnHpFull;
    public FloatEvent OnRemoveHp;
    public FloatEvent OnAddHp;

    private float regenerateHpTimer;
    private bool healEnabled = true;
    float _healingAmount;
    float _maxHp;

    void Start()
    {
        SetHealthMulti(1f);
    }

    void Update()
    {
        if (healEnabled)
        {
            regenerateHpTimer += Time.deltaTime;
            if (regenerateHpTimer >= regenerateHpDelay && hp < _maxHp)
                AddHp(_healingAmount * Time.deltaTime);
        }
    }

    public void SetHp(float hp)
    {
        if (this.hp != hp && enabled)
        {
            this.hp = Mathf.Clamp(hp, 0f, _maxHp);

            OnSendNormalizedHp?.Invoke(this.hp / _maxHp);
            OnSendHp?.Invoke(this.hp);

            if (this.hp <= 0)
            {
                OnHpEmpty.Invoke();
            }
            else if (this.hp >= _maxHp)
            {
                OnHpFull?.Invoke(this.hp);
            }
        }
    }

    public void SetMaxHp(float max)
    {
        if (_maxHp != max && max != 0 && enabled)
        {
            _maxHp = max;
        }
    }

    public void RemoveHp(float hp)
    {
        SetHp(this.hp - hp);
        OnRemoveHp?.Invoke(this.hp);
        regenerateHpTimer = 0f;
    }

    public void AddHp(float hp)
    {
        SetHp(this.hp + hp);
        OnAddHp?.Invoke(this.hp);
    }

    public float GetHp() => hp;
    public float GetMaxHp() => _maxHp;

    public void SetHealEnableState(bool b) => healEnabled = b;
    public void SetHealingMulti(float m) { _healingAmount = regenerateHpPerSec * m; }
    public void SetHealthMulti(float m)
    {
        SetMaxHp(maxHp * m);
        SetHp(GetMaxHp());
    }
}
