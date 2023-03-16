using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class Building : MonoBehaviour
{
    [SerializeField] private float _incomePeriod = 5;
    [SerializeField] private int _income = 15;
    [SerializeField] private TMP_Text _incomeUI;
    [SerializeField] private CanvasGroup _infoUICanvasGroup;
    
    private PlayerResources _playerResources;
    private Coroutine _infoUIFadeRoutine;

    private void Awake()
    {
        // Not Optimized, change to Singleton
        _playerResources = FindObjectOfType<PlayerResources>();
    }

    private void Start()
    {
        StartCoroutine(IncomeRoutine());
    }

    [ContextMenu("OnHoverEnter")]
    public void OnHoverEnter()
    {
        InfoUIFade(1f);
    }
    
    [ContextMenu("OnHoverExit")]
    public void OnHoverExit()
    {
        InfoUIFade(0f);
    }

    private void InfoUIFade(float opacity)
    {
        if (_infoUIFadeRoutine != null) StopCoroutine(_infoUIFadeRoutine);
        _infoUIFadeRoutine = StartCoroutine(InfoUIFadeRoutine(opacity));
    }

    private IEnumerator InfoUIFadeRoutine(float opacity)
    {
        float t = 0;
        float initialAlpha = _infoUICanvasGroup.alpha;
        while (t < 1)
        {
            _infoUICanvasGroup.alpha = Mathf.Lerp(initialAlpha, opacity, t);
            t += Time.deltaTime * 4;
            yield return null;
        }

        _infoUIFadeRoutine = null;
    }
    
    private IEnumerator IncomeRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(_incomePeriod);
            _playerResources.AddMoney(_income);
            StartCoroutine(ShowIncomeUIRoutine());
        }
    }

    private IEnumerator ShowIncomeUIRoutine()
    {
        _incomeUI.gameObject.SetActive(true);
        _incomeUI.text = "+" + _income;
        yield return new WaitForSeconds(1);
        _incomeUI.gameObject.SetActive(false);
    }
    
}
