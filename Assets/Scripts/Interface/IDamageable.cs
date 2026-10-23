using UnityEngine;

public interface IDamageable
{
    Color DamageColor { get; }
    void TakeDamage();
}
