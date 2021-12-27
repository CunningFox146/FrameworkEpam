using FrameworkEpam.Model;
using FrameworkEpam.Utils;
using System;

namespace FrameworkEpam.Service
{
    public static class ApiConfigCreator
    {
        public static ApiConfig CreateRandomValid()
        {
            return new ApiConfig() { Name = "123", CIDR = "", Permission = 1 };
        }

        public static ApiConfig CreateWithInvalidCIDR() => new ApiConfig() { Name = "123", CIDR = "123", Permission = 0 };
}
}
