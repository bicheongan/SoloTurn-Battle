using UnityEngine;
using System.Collections.Generic;
public class StageManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _nodes;
    private int _count = 0;

    private void Start()
    {
        Deactivate();
        SceneChanger.CloseScene += NextNode;
    }
    private void NextNode()
    {
        _nodes[_count].SetActive(false);
        _nodes[_count + 1].SetActive(true);
        _count++;
    }
    private void Deactivate()
    {
        for (int i = 1; i < _nodes.Count; i++)
        {
            _nodes[i].SetActive(false);
        }
    }
    private void OnDestroy()
    {
        SceneChanger.CloseScene -= NextNode;
    }
}
