using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISampleA
{
    string SecretCode { get; }
    void PrintMessage();
}

public class SampleA : ISampleA
{
    ISampleB sampleBDependency;

    public string SecretCode => "This is secret code of A...asdasdasdasd";

    public void PrintMessage()
    {
        Debug.Log($"This is Sample A, and B said..{sampleBDependency.SecretCode}");
    }
}
