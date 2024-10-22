using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPath
{
    void SetPathParams(List<float> pathParams);
    void Move();
}
