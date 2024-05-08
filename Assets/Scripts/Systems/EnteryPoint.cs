using UnityEngine;

public class EnteryPoint : MonoBehaviour
{
    [SerializeField] private BuildTower _buildTower;
    [SerializeField] private Zombi_spawner _zombi_spawner;
    [SerializeField] private CointSystem _cointSystem;
    [SerializeField] private TimeController _timeController;

    private void Awake()
    {
        Init();
        Register();
    }

    private void Init()
    {
        _zombi_spawner.Init();
        _cointSystem.Init();
        _timeController.Init();
        Debug.Log("Initializated");
    }

    private void Register()
    {
        ServiceLocator.Initialize();

        ServiceLocator.Current.Register<Zombi_spawner>(_zombi_spawner);
        ServiceLocator.Current.Register<CointSystem>(_cointSystem);
        ServiceLocator.Current.Register<BuildTower>(_buildTower);
        Debug.Log("Registreted");
    }
}
