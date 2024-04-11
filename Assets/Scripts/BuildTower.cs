using UnityEngine;


public class BuildTower : MonoBehaviour
{
    private CointSystem cointSystem;
    private Color startColor = Color.white;
    private Renderer rend;
    private bool canBuild = true;
    int currentBuildIndex;
    [SerializeField] private Color howerColor = Color.gray;
    [SerializeField] private GameObject[] towers;

    void Awake()
    {
        rend = GetComponent<Renderer>();
        cointSystem = FindAnyObjectByType<CointSystem>();
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
        int sell = towers[index].GetComponentInChildren<Turret1>()._value;
        if (cointSystem._coints >= sell && canBuild == true)
        {
            cointSystem._coints -= sell;
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
