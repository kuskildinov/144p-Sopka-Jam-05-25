using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutScenePanel : MonoBehaviour
{
    private const float PAGE_FADE_TIME = 3f;

    [SerializeField] private List<CutScenePage> _cutScenePages;
    private CutSceneRoot _root;
    private IInput _input;
    private bool _cutSceneOpend;
    private int _currentPageIndex;
    public void Initialize(CutSceneRoot root, IInput input)
    {
        _root = root;
        _input = input;
        _currentPageIndex = 0;
        StartCoroutine(OpenFirstPageRoutine());
     
    }

    private void Update()
    {
        if (!_cutSceneOpend)
            return;

        if(_input.AnyKeyDown())
        {
            _cutSceneOpend = false;
            TryOpenNextPage();
        }
    }

    private void TryOpenNextPage()
    {
        StartCoroutine(OpenNextPageRoutine());
    }

    private IEnumerator OpenFirstPageRoutine()
    {
        _cutScenePages[_currentPageIndex].gameObject.SetActive(true);
        yield return null;
        _cutScenePages[_currentPageIndex].Open();
        yield return new WaitForSecondsRealtime(PAGE_FADE_TIME);
        _cutSceneOpend = true;
        yield break;
    }
    private IEnumerator OpenNextPageRoutine()
    {
        _cutScenePages[_currentPageIndex].Close();
        yield return new WaitForSecondsRealtime(PAGE_FADE_TIME);
        _cutScenePages[_currentPageIndex].gameObject.SetActive(false);
        _currentPageIndex++;
        yield return null;
        if(_currentPageIndex < _cutScenePages.Count)
        {
            _cutScenePages[_currentPageIndex].gameObject.SetActive(true);
            yield return null;
            _cutScenePages[_currentPageIndex].Open();
            yield return new WaitForSecondsRealtime(PAGE_FADE_TIME);
            _cutSceneOpend = true;
        }
        else
        {
            _root.LoadNextScene();
        }

        yield return null;
        yield break;
    }
}
