using UnityEngine;
[RequireComponent(typeof(Renderer))]

public class BuildTower : MonoBehaviour, IServiceLocator
{
    [SerializeField] private Color howerColor = Color.gray;
    [SerializeField] private GameObject[] towers;

    private Color startColor = Color.white;
    private Renderer rend;
    private bool canBuild = true;
    int currentBuildIndex;

    private CointSystem _cointSystem;

    public void Start()
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
            canBuild = false;
        }

        else
            return;
    }

    private void Turret1(int index)
    {
        currentBuildIndex = index;
    }

    private void getIBuild(int index)
    {
        int sell = towers[index].GetComponentInChildren<Turret>()._value;
        if (_cointSystem._coints >= sell && canBuild == true)
        {
            _cointSystem._coints -= sell;
            towers[index].SetActive(true);
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
