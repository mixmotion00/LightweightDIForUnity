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

        private void Awake()
        {
            // create container object
            _diContainer = new LightweightDI();

            // create any classess
            _sampleA = new SampleA();
            _sampleB = new SampleB();

            // register container
            _diContainer.Register(_sampleA);
            _diContainer.Register(_sampleB);

            // auto inject dependencies
            _diContainer.BindDependencies();
        }

        private void Start()
        {
            _sampleA.PrintMessage();
            _sampleB.PrintMessage();
        }

        private void Update()
        {

        }

        private void FixedUpdate()
        {

        }
    }
}
