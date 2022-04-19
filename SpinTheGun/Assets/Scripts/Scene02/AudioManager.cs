using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource = null;
    [SerializeField] private AudioClip coinCollectClip = null;
    [SerializeField] private AudioClip gunFireClip = null;
    [SerializeField] private AudioClip gunBackForceClip = null;
    [SerializeField] private AudioClip gunPickUpClip = null;
    [SerializeField] private AudioClip gameOverClip = null;
    [SerializeField] private AudioClip redZoneClip = null;
    [SerializeField] private AudioClip buttonClickClip = null;


    private static AudioSource _audioSource = null;
    private static AudioClip _coinCollectClip= null;
    private static AudioClip _gunFireClip = null;
    private static AudioClip _gunBackForceClip = null;
    private static AudioClip _gunPickUpClip = null;
    private static AudioClip _gameOverClip = null;
    private static AudioClip _redZoneClip = null;
    private static AudioClip _buttonClickClip = null;



    // Start is called before the first frame update
    void Start()
    {
        PlayAudio();
    }
    public void PlayAudio()
    {
        _audioSource = audioSource;
        _coinCollectClip = coinCollectClip;
        _gunFireClip = gunFireClip;
        _gunBackForceClip = gunBackForceClip;
        _gunPickUpClip = gunPickUpClip;
        _gameOverClip = gameOverClip;
        _redZoneClip = redZoneClip;
        _buttonClickClip = buttonClickClip;
    }

    public static void PlayCoinCollectClip()
    {
        _audioSource.PlayOneShot(_coinCollectClip);
    }   

    public static void PlayGunFireClip()
    {
        _audioSource.PlayOneShot(_gunFireClip);
    }

    public static void PlayGunBackForceClip()
    {
        _audioSource.PlayOneShot(_gunBackForceClip);
    }
    public static void PlayGunPickUpClip()
    {
        _audioSource.PlayOneShot(_gunPickUpClip);
    }
    public static void PlayGameOverClip()
    {
        _audioSource.PlayOneShot(_gameOverClip);
    }
    public static void PlayRedZoneClip()
    {
        _audioSource.PlayOneShot(_redZoneClip);
    }
    public static void PlayButtonClickClip()
    {
        _audioSource.PlayOneShot(_buttonClickClip);
    }
}
