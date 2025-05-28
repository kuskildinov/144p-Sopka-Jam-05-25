using Cinemachine;
using System.Collections;
using UnityEngine;

public class SwapHouseTrigger : MonoBehaviour
{
    public float _teleportDuration = 0.5f;
    [SerializeField] private SwapHouseTrigger _targetTrigger;
    [SerializeField] private Transform _standPoint;
    [SerializeField] private CinemachineVirtualCamera _virtualCam;
    private CinemachineFramingTransposer _framingTransposer;
    private bool isTeleporting = false;

    public Transform StandPoint => _standPoint;
    public bool IsTeleporting => isTeleporting;

    public void TeleportPlayer(GameObject player)
    {
        if (_targetTrigger == null)
            return;
        _framingTransposer = _virtualCam.GetCinemachineComponent<CinemachineFramingTransposer>();
        StartCoroutine(TeleportationRoutine(player));              
    }

    private IEnumerator TeleportationRoutine(GameObject player)
    {
        isTeleporting = true;

        // 1. Отключаем слежение камеры
        if (_framingTransposer != null)
        {
            _framingTransposer.enabled = false;
        }

        // 2. Затемнение экрана (опционально)
        // Можно добавить UI Image с анимацией альфа-канала

        yield return new WaitForSeconds(_teleportDuration * 0.3f);

        // 3. Телепортация
        player.transform.position = _targetTrigger.StandPoint.transform.position;

        yield return new WaitForSeconds(_teleportDuration * 0.2f);

        // 4. Включаем слежение обратно
        if (_framingTransposer != null)
        {
            _framingTransposer.enabled = true;
        }

        // 5. Осветление экрана (опционально)

        yield return new WaitForSeconds(_teleportDuration * 0.5f);

        isTeleporting = false;
    }
}
