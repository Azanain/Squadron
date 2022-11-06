using Zenject;
using UnityEngine;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private Player player;
    public override void InstallBindings()
    {
        Container.Bind<Player>().FromInstance(player).AsSingle().NonLazy();
        Container.QueueForInject(player);
    }
}
