﻿namespace PCHCB.Web.ViewModels.Case
{
    using PCHCB.Web.ViewModels.PcConfiguration;
    using PCHCB.Web.ViewModels.Provider;

    /// <summary>
    /// Full info about Case
    /// </summary>
    public class CaseDetailsViewModel : CaseAllViewModel
    {
        public int FormFactor { get; set; } 

        public int CaseSize { get; set; } 

        public int PsuFactor { get; set; }

        public int MaxGpuLength { get; set; }

        public double MaxAirCpuCoolerHeight { get; set; }

        public int MaxStorageDevices { get; set; }

        public int MaxRadiatorLength { get; set; }

        public ProviderInfoViewModel Provider { get; set; } = null!;

        public AssembleConfigurationFormModel Assemble { get; set; } = null!;
    }
}
