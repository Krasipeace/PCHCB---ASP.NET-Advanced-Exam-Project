﻿namespace PCHCB.Web.ViewModels.Gpu
{
    using PCHCB.Web.ViewModels.Provider;

    public class GpuDetailsViewModel : GpuAllViewModel
    {
        public int Memory { get; set; }

        public int Interface { get; set; }

        public double Length { get; set; }

        public double SlotsRequired { get; set; }

        public int PowerConsumption { get; set; }

        public bool NvidiaConnector { get; set; }

        public string Description { get; set; } = null!;

        public ProviderInfoViewModel Provider { get; set; } = null!;
    }
}