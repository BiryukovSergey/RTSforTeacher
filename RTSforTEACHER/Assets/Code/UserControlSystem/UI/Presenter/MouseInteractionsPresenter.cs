using System;
using System.Linq;
using Abstractions;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;
using UserControlSystem;
using Zenject;

public class MouseInteractionsPresenter : MonoBehaviour
{
    #region Старый код

     /* [SerializeField] private EventSystem _eventSystem;
         [SerializeField] private Camera _camera;
         [SerializeField] private SelectableValue _selectedObject;
         [SerializeField] private Vector3Value _groundClicksRMB;
         [SerializeField] private Transform _groundTransform;
         private Plane _groundPlane;
         private void Start()
         {
         _groundPlane = new Plane(_groundTransform.up, 0);
         }
         private void Update()
         {
             if (!Input.GetMouseButtonUp(0) && !Input.GetMouseButton(1))
             {
                 return;
             }
             if (_eventSystem.IsPointerOverGameObject())
             {
                 return;
             }
             var ray = _camera.ScreenPointToRay(Input.mousePosition);
             if (Input.GetMouseButtonUp(0))
             {
                 var hits = Physics.RaycastAll(ray);
                 if (hits.Length == 0)
                 {
                     return;
                 }
                 var selectable = hits
                     .Select(hit =>
                         hit.collider.GetComponentInParent<ISelecatable>())
                     .Where(c => c != null)
                     .FirstOrDefault();
                 _selectedObject.SetValue(selectable);
             }
             else
             {
                 if (_groundPlane.Raycast(ray, out var enter))
                 {
                     _groundClicksRMB.SetValue(ray.origin + ray.direction
                         * enter);
                 }
             }
         }*/

    #endregion
    
    [SerializeField] private EventSystem _eventSystem;
    [SerializeField] private Camera _camera;
    [SerializeField] private SelectableValue _selectedObject;
    [SerializeField] private Vector3Value _groundClicksRMB;
    [SerializeField] private AttackableValue _attackablesRMB;
    [SerializeField] private Transform _groundTransform;
    private Plane _groundPlane;

    [Inject]
    private void Init()
    {
        _groundPlane = new Plane(_groundTransform.up, 0);
        var nonBlockedByUiFramesStream = Observable.EveryUpdate().Where(_ => !_eventSystem.IsPointerOverGameObject());
        var leftClicksStream = nonBlockedByUiFramesStream.Where(_ => Input.GetMouseButtonDown(0));
        var rightClicksStream = nonBlockedByUiFramesStream.Where(_ => Input.GetMouseButtonDown(1));
        var lmbRays = leftClicksStream.Select(_ => _camera.ScreenPointToRay(Input.mousePosition));
        var rmbRays = rightClicksStream.Select(_ => _camera.ScreenPointToRay(Input.mousePosition));
        var lmbHitsStream = lmbRays.Select(ray => Physics.RaycastAll(ray));
        var rmbHitsStream = rmbRays.Select(ray => (ray, Physics.RaycastAll(ray)));
        lmbHitsStream.Subscribe(hits =>
        {
            if (weHit<ISelecatable>(hits, out var selectable))
            {
                _selectedObject.SetValue(selectable);
            }
        });
        rmbHitsStream.Subscribe(data =>
        {
            var (ray, hits) = data;
            if (weHit<IAttackable>(hits, out var attackable))
            {
                _attackablesRMB.SetValue(attackable);
            }
            else if (_groundPlane.Raycast(ray, out var enter))
            {
                _groundClicksRMB.SetValue(ray.origin + ray.direction * enter);
            }
        });
    }

    private bool weHit<T>(RaycastHit[] hits, out T result) where T : class
    {
        result = default;
        if (hits.Length == 0)
        {
            return false;
        }
        result = hits.Select(hit => hit.collider.GetComponentInParent<T>()).Where(c => c != null).FirstOrDefault();
        return result != default;
    }
}