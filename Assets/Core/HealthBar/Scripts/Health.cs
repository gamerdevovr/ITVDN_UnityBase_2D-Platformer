using UnityEngine;
using UnityEngine.UI;

namespace Platformer.Core.HealthBar
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private int _decreaseCount;
        [SerializeField] private int _healthCount;
        [SerializeField] private float _healthRecoveryIntervalInSecond;

        public int HealthCount => _healthCount;

        private Image _healthImage;
        private float _timer;

        private void Awake()
        {
            _healthImage = GetComponent<Image>();
        }

        private void Update()
        {
            UpdateHealth();
            UpdateUI();
        }

        public void DecreaseHealth()
        {
            if (_healthCount <= 0)
            {
                return;
            }

            _healthCount -= _decreaseCount;
        }

        private void UpdateHealth()
        {
            _timer += Time.deltaTime;

            if (_healthCount < 100 && _timer >= _healthRecoveryIntervalInSecond)
            {
                _healthCount++;
                _timer = 0f;
            }
        }

        private void UpdateUI()
        {
            _healthImage.fillAmount = _healthCount / 100f;
        }
    }
}
