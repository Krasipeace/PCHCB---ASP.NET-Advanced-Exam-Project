﻿namespace PCHCB.Web.ViewModels.Cpu
{
    using PCHCB.Web.ViewModels.PcConfiguration;
    using PCHCB.Web.ViewModels.Provider;

    /// <summary>
    /// Full info about CPU
    /// </summary>
    public class CpuDetailsViewModel : CpuAllViewModel
    {
        public string Socket { get; set; } = null!;

        public int Cores { get; set; }

        public int Threads { get; set; }

        public int Frequency { get; set; }

        public int TurboFrequency { get; set; }

        public int Cache { get; set; }

        public int Tdp { get; set; }

        public int RamFrequency { get; set; }

        public int RamType { get; set; }

        public ProviderInfoViewModel Provider { get; set; } = null!;

        public AssembleConfigurationFormModel Assemble { get; set; } = null!;
    }
}
