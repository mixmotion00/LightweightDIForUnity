using UnityEngine;

namespace Mixmotion00 {
    /// <summary>
    /// Only script to resolve all dependencies
    /// </summary>
    public class MainLoader : MonoBehaviour
    {
        private LightweightDI _diContainer;
        private ISampleA _sampleA;
        private ISampleB _sampleB;

        private IManagerPrefab _managerPrefab;

        private void Awake()
        {
            // create container object
            _diContainer = new LightweightDI();

            // create any classess
            _sampleA = new SampleA();
            _sampleB = new SampleB();
            _managerPrefab = new ManagerPrefab();

            // register container
            _diContainer.Register(_sampleA);
            _diContainer.Register(_sampleB);
            _diContainer.Register(_managerPrefab);

            // auto inject dependencies
            _diContainer.BindDependencies();
        }

        private void Start()
        {
            _managerPrefab.Init(_diContainer);

            _sampleA.PrintMessage();
            _sampleB.PrintMessage();

            //test create gameobject using managerprefab di
            SampleCube sampleCube = _managerPrefab.Instantiate<SampleCube>("Sample/SampleCube");
        }

        private void Update()
        {

        }

        private void FixedUpdate()
        {

        }
    }
}
