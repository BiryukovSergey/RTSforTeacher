using System.Text;
using Abstractions;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.UserControlSystem.UI.Presenter
{
    public class GameOverScreenPresenter : MonoBehaviour
    {
        [Inject] private IGameStatus _gameStatus;
        [SerializeField] private Text _text;
        [SerializeField] private GameObject _view;
        [Inject]
        private void Init()
        {
            _gameStatus.Status.ObserveOnMainThread().Subscribe(result =>
            {
                var sb = new StringBuilder($"Game Over!");
                if (result == 0)
                {
                    sb.AppendLine("Ничья!");
                }
                else
                {
                    sb.AppendLine($"Победила партия №{result}");
                }
                _view.SetActive(true);
                _text.text = sb.ToString();
                Time.timeScale = 0;
            });
        }

    }
}