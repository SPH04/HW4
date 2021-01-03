using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _speed;

    private Slider _healthBar;

    private float GetNormalizedHealth => 
        _player.Health / (float)_player.MaxHealth;

    private void Start()
    {
        _healthBar = GetComponent<Slider>();
        _healthBar.value = GetNormalizedHealth;
    }
    private void FixedUpdate()
    {
        if (GetNormalizedHealth != _healthBar.value)
        {
            if (Mathf.Abs(GetNormalizedHealth - _healthBar.value) <= 0.01f)
                _healthBar.value = GetNormalizedHealth;
            else
                _healthBar.value = Mathf.Lerp(_healthBar.value, GetNormalizedHealth, _speed);
        }
    }
}
