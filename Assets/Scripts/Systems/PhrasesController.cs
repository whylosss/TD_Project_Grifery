using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PhrasesController : MonoBehaviour
{
    [SerializeField] private AudioClip[] _enemyPrases;
    [SerializeField] private AudioClip _secoundsLeft;
    [SerializeField] private AudioClip _turretDestroyed;

    private AudioSource _audioSource;
    private int _index = 0;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        Enemy_life.playPhrase += PlayEnemyPhrases;
        Obstacle.playPharase += PlayTurretDestroyed;
        TimeController.playPhrase += PlaySecoundsLeft;
    }

    private void OnDisable()
    {
        Enemy_life.playPhrase -= PlayEnemyPhrases;
        Obstacle.playPharase -= PlayTurretDestroyed;
        TimeController.playPhrase += PlaySecoundsLeft;
    }

    private void PlayEnemyPhrases()
    {
            _index = Random.Range(0, _enemyPrases.Length + 1);
            _audioSource.PlayOneShot(_enemyPrases[_index]);
    }

    private void PlaySecoundsLeft()
    {
        _audioSource.PlayOneShot(_secoundsLeft);
    }

    private void PlayTurretDestroyed()
    {
            _audioSource.PlayOneShot(_turretDestroyed);
    }
}
