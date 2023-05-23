using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthSystem : MonoBehaviour {
    [SerializeField, Min(0)] float hp;
    [SerializeField, Min(0)] float maxHp = 100f;

    [Space(8), Header("Events")]
    public FloatEvent OnSendNormalizedHp;
    public FloatEvent OnSendHp;
    public UnityEvent OnHpEmpty;
    public FloatEvent OnHpFull;
    public FloatEvent OnRemoveHp;
    public FloatEvent OnAddHp;

    void Start() {
        SetHp(maxHp);
    }

    public void SetHp(float hp) {
        if (this.hp != hp) {
            this.hp = Mathf.Clamp(hp, 0f, this.maxHp);

            OnSendNormalizedHp?.Invoke(this.hp / this.maxHp);
            OnSendHp?.Invoke(this.hp);

            if (this.hp <= 0) {
                OnHpEmpty.Invoke();
            } else if (this.hp >= this.maxHp) {
                OnHpFull?.Invoke(this.hp);
            }
        }
    }

    public void RemoveHp(float hp) {
        SetHp(this.hp - hp);
        OnRemoveHp?.Invoke(this.hp);
    }

    public void AddHp(float hp) {
        SetHp(this.hp + hp);
        OnAddHp?.Invoke(this.hp);
    }

    [ContextMenu("Add 10 Hp")]
    public void AddBy10() => AddHp(10);

    [ContextMenu("Remove 10 Hp")]
    public void RemoveBy10() => RemoveHp(10);
}
