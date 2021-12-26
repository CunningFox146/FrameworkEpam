using System;

namespace FrameworkEpam.Model
{
    public class AddressRecord
    {
        private int _currency = 0;

        public string Name { get; set; }
        public string Address { get; set; }
        public string Note { get; set; }
        public int Currency { get => _currency; set => Math.Clamp(_currency, 0, 1); }
        public bool IsSkipConfirm { get; set; }

        public AddressRecord(string name, string address, int currency = 0, string note = "", bool isSkipConfirm = false)
        {
            Name = name;
            Address = address;
            Currency = currency;
            Note = note;
            IsSkipConfirm = isSkipConfirm;
        }
    }
}
