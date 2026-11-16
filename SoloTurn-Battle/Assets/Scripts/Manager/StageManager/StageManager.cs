using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
public class StageManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _nodes;
    [SerializeField] private List<Button> _Button;
    private int _count = 0;

    private void Start()
    {
        Deactivate();
        SceneChanger.CloseScene += NextNode;
    }
    private void NextNode()
    {
        _Button[_count].interactable = false;
        _Button[_count + 1].interactable = true;
        _count++;
    }
    private void Deactivate()
    {
        for (int i = 1; i < _nodes.Count; i++)
        {
            _Button[i].interactable = false;
        }
    }
    private void OnDestroy()
    {
        SceneChanger.CloseScene -= NextNode;
    }
}
