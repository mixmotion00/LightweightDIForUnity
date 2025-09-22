using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISampleB
{
    void PrintMessage();
    string SecretCode { get; }
}

public class SampleB : ISampleB
{
    ISampleA sampleADependency;

    public string SecretCode { get { return "Shhh..this B and the secret code is..asdasdas"; } }

    public void PrintMessage()
    {
        Debug.Log($"This is Sample B, just know A secret is:{sampleADependency.SecretCode}");
    }
}
