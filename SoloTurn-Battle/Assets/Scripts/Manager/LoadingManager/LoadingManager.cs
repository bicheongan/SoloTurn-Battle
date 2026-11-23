using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingManager : MonoBehaviour
{
    public static LoadingManager Instance{ get; private set; }
    [SerializeField] private  CanvasGroup _canvasGroup;
    [SerializeField] private Image _loadingFillBar;
    [SerializeField] private float _minLoadingTime;
    private bool _isLoading;

    private void Awake()
    {
        SetSingleton();
    }
    public void StartLoading(string scenename)
    {
        if (_isLoading == true) return;
        StartCoroutine(LoadingDelay(scenename));
    }

    private IEnumerator LoadingDelay(string scenename)
    {
        _canvasGroup.alpha = 1;
        _canvasGroup.blocksRaycasts = true;
        _isLoading = true;
        AsyncOperation op = SceneManager.LoadSceneAsync(scenename);
        if (op == null)
        {
            Debug.Log("로딩 오류");
            _canvasGroup.alpha = 0;
            _canvasGroup.blocksRaycasts = false;
            _isLoading = false;
            yield break;
        }
        op.allowSceneActivation = false;
        float elapsedTime = 0;
        while(op.progress < 0.9f || elapsedTime < _minLoadingTime)
        {
            elapsedTime += Time.unscaledDeltaTime;
            float loadingrate = op.progress/0.9f;
            float timerate = elapsedTime / _minLoadingTime;
            _loadingFillBar.fillAmount = Mathf.Min(loadingrate, timerate);

            yield return null;
        }
        _loadingFillBar.fillAmount = 1;
        yield return new WaitForSecondsRealtime(0.5f);
        op.allowSceneActivation = true;
        yield return op;
        _canvasGroup.blocksRaycasts = false;
        _canvasGroup.alpha = 0;
        _loadingFillBar.fillAmount = 0;
        _isLoading = false;
    }

    private void SetSingleton()
    {
        if(Instance != null &&  Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
