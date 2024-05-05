using System;
using UnityEngine;
[RequireComponent(typeof(Renderer))]

public class BuildTower : MonoBehaviour, IServiceLocator
{
    [SerializeField] private Color howerColor = Color.gray;
    [SerializeField] private GameObject[] towers;

    private Color startColor = Color.black;
    private Renderer rend;
    private bool canBuild = true;
    int currentBuildIndex;

    private CointSystem _cointSystem;

    private void Start()
    {
        _cointSystem = ServiceLocator.Current.Get<CointSystem>();
        rend = GetComponent<Renderer>();
        foreach (GameObject gameObject in towers)
        {
            gameObject.SetActive(false);
        }
    }
    private void OnEnable()
    {
        PanelController.unlock += Turret1;
    }

    private void OnMouseUpAsButton()
    {
        if (canBuild == true)
        {
            getIBuild(currentBuildIndex);
        }

        else
            return;
    }

    private void Turret1(int index)
    {
        currentBuildIndex = index;
        Debug.Log(index);
    }

    private void getIBuild(int index)
    {
        int sell = towers[index].GetComponentInChildren<Turret>()._value;
        if (_cointSystem.Coins >= sell && canBuild == true)
        {
            towers[index].SetActive(true);
            _cointSystem.Coins -= sell;
            canBuild = false;
        }
    }

    private void OnMouseEnter()
    {
        if (canBuild)
            rend.material.color = howerColor;
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
