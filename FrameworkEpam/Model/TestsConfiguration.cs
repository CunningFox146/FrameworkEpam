﻿using Newtonsoft.Json;
using System.Collections.Generic;

namespace FrameworkEpam.Model
{
    public class TestsConfiguration
    {
        public string LogsPath { get; set; }
        public string UIMapPath { get; set; }
        public string Browser { get; set; }
        public string DriverPath { get; set; }
        public string ScreenshotsPath { get; set; }
        public string DownloadPath { get; set; }

        public User User { get; set; }

        public OrderData LimitOrder { get; set; }
        public OrderData MarketOrder { get; set; }
        public OrderData MarketStopOrder { get; set; }

        public UIMapConfiguration UIMapConfig { get; set; }

        public TestsConfiguration FillDefaultValues()
        {
            User = new User("makar.papca@gmail.com", "Cunning84");
            UIMapConfig = new UIMapConfiguration().FillDefaultValues();

            return this;
        }
    }
}
