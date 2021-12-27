using FrameworkEpam.Model;
using FrameworkEpam.Utils;
using System;

namespace FrameworkEpam.Service
{
    public static class AddressRecordCreator
    {
        public static AddressRecord CreateRandomValid()
        {
            var random = new Random();

            return new AddressRecord(
                StringUtil.RandomString(5 + random.Next(5)),
                "mkHS9ne12qx9pS9VojpwU5xtRd4T7X7ZUt",
                random.Next(1),
                StringUtil.RandomString(5 + random.Next(5)),
                random.Next(1) == 0
            );
        }

        public static AddressRecord CreateWithEmptyName() => new AddressRecord("", "123xyz");
        public static AddressRecord CreateWithEmptyAddress() => new AddressRecord("123xyz", "");
    }
}
