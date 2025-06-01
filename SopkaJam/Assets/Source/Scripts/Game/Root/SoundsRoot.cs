using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsRoot : CompositeRoot
{
    public static SoundsRoot Instance;
    [SerializeField] private AudioSource _mainSource;
    [SerializeField] private AudioSource _playerSource;
    [SerializeField] private AudioSource _tigerSource;
    [Header("Sounds")]
    [Header("Menu")]
    [SerializeField] private AudioClip _buttonsSound;
    [Header("Player")]
    [SerializeField] private AudioClip _playerTakeDamage;
    [SerializeField] private AudioClip _playerDash;
    [SerializeField] private AudioClip _takeItem;
    [SerializeField] private AudioClip _leaveHouse;
    [Header("Tiger")]
    [SerializeField] private AudioClip _meetTigerSound;
    [SerializeField] private AudioClip _tigerAttackSound;
    [SerializeField] private AudioClip _bossAttackSound;
    public override void Compose()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this.gameObject);
    }

    public void PlayButtonsound()
    {
        _mainSource.PlayOneShot(_buttonsSound);
    }

    public void PlayTakeDamageSound()
    {
        _playerSource.PlayOneShot(_playerTakeDamage);
    }

    public void PlayDashSound()
    {
        _playerSource.PlayOneShot(_playerTakeDamage);
    }

    public void PlayTakeItemSound()
    {
        _playerSource.PlayOneShot(_takeItem);
    }

    public void PlayLeaveHouseSound()
    {
        _playerSource.PlayOneShot(_leaveHouse);
    }

    public void PlayMeetTigerSound()
    {
        _tigerSource.PlayOneShot(_meetTigerSound);
    }

    public void PlayTigerAttackSound()
    {
        _tigerSource.PlayOneShot(_tigerAttackSound);
    }

    public void PlayBossAttackSoound()
    {
        _tigerSource.PlayOneShot(_bossAttackSound);
    }
}
