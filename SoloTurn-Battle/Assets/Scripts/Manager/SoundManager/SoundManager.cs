using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }
    [Header("오디오소스")]
    [SerializeField] private AudioSource _bgmSource;
    [SerializeField] private AudioSource _effectSource;
    [Header("오디오클립")]
    [SerializeField] private AudioClip[] _bgm;
    [SerializeField] private AudioClip[] _effectbgm;

    private void Awake()
    {
        SetSingleton();
    }

    private void SetSingleton()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
