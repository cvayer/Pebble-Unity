using System;

public interface IPool
{
    void Free(IPoolable poolable);
}

