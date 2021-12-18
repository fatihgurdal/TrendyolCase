using System;
using System.Collections.Generic;
using System.Text;

namespace LinkConverter.Domain.Service
{
    public interface ITestService
    {
        int Add(string name, byte age);
        string GetAll();
    }
}
