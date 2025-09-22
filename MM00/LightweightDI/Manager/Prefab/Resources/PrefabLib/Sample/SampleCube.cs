using UnityEngine;

public class SampleCube : MonoBehaviour
{
    ISampleA _sampleA;
    ISampleB _sampleB;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log($"Called from sampleCube Start");
        _sampleA.PrintMessage();
        _sampleB.PrintMessage();
        Debug.Log($"Called from sampleCube End");
    }
}
