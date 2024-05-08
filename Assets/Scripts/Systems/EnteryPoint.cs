using UnityEngine;

public class EnteryPoint : MonoBehaviour
{
    [SerializeField] private VolumeController _volumeController;
    [SerializeField] private BuildTower _buildTower;
    [SerializeField] private zombi_object_pool _zombi_object_pool;
    [SerializeField] private Zombi_spawner _zombi_spawner;
    [SerializeField] private CointSystem _cointSystem;
    [SerializeField] private TimeController _timeController;
    [SerializeField] private GameUI _gameUI;

    private void Awake()
    {
        Init();
        Register();
    }

    private void Init()
    {
        _volumeController.Init();
        _zombi_object_pool.Init1();
        _zombi_object_pool.Init2();
        _zombi_spawner.Init();
        _cointSystem.Init();
        _timeController.Init();
        _gameUI.Init();
        Debug.Log("Initializated");
    }

    private void Register()
    {
        ServiceLocator.Initialize();

        ServiceLocator.Current.Register<VolumeController>(_volumeController);
        ServiceLocator.Current.Register<zombi_object_pool>(_zombi_object_pool);
        ServiceLocator.Current.Register<Zombi_spawner>(_zombi_spawner);
        ServiceLocator.Current.Register<CointSystem>(_cointSystem);
        ServiceLocator.Current.Register<BuildTower>(_buildTower);
        ServiceLocator.Current.Register<GameUI>(_gameUI);
        Debug.Log("Registreted");
    }
}
