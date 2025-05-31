using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutScenePanel : MonoBehaviour
{
    private const float PAGE_FADE_OUT_TIME = 2f;

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
        _cutScenePages[0].gameObject.SetActive(true);       
        _cutSceneOpend = true;
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
        StartCoroutine(OpenPageRoutine());
    }
    private IEnumerator OpenPageRoutine()
    {
        _cutScenePages[_currentPageIndex].Close();
        yield return new WaitForSecondsRealtime(PAGE_FADE_OUT_TIME);
        _cutScenePages[_currentPageIndex].gameObject.SetActive(false);
        _currentPageIndex++;
        if(_currentPageIndex < _cutScenePages.Count)
        {
            _cutScenePages[_currentPageIndex].gameObject.SetActive(true);
            yield return new WaitForSecondsRealtime(2f);
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
