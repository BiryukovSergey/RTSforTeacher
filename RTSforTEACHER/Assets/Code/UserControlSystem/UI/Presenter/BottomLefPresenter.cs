using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Abstractions;
using UniRx;
using Zenject;

namespace UserControlSystem
{

    public class BottomLefPresenter : MonoBehaviour
    {
        [SerializeField] private Image _selectedImage;
        [SerializeField] private Slider _healthSlider;
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private Image _sliderBackground;
        [SerializeField] private Image _sliderFillImage;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        
        [Inject] private IObservable<ISelecatable> _selectedValues;

        
        
        private void Start()
        {
            _selectedValues.Subscribe(onSelected);
        }

        private void onSelected(ISelecatable selected)
        {
            _selectedImage.enabled = selected != null;
            _healthSlider.gameObject.SetActive(selected != null);
            _text.enabled = selected != null; 
            _spriteRenderer.enabled = false;
            
            if (selected != null)
            {
                _spriteRenderer.transform.position = selected.PositionIllusion;
                _spriteRenderer.enabled = true;
                _selectedImage.sprite = selected.Icon;
                _text.text = $"{selected.Health}/{selected.MaxHealth}";
                _healthSlider.minValue = 0;
                _healthSlider.maxValue = selected.MaxHealth;
                _healthSlider.value = selected.Health;
                var color = Color.Lerp(Color.red, Color.green, selected.Health /
                                                               (float) selected.MaxHealth);
                _sliderBackground.color = color * 0.5f;
                _sliderFillImage.color = color;
            }
        }
    }
}