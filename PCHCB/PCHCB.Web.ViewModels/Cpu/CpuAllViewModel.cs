﻿namespace PCHCB.Web.ViewModels.Cpu
{
    using PCHCB.Web.ViewModels.Contracts;

    /// <summary>
    /// Short info about CPU
    /// </summary>
    public class CpuAllViewModel : IProtectedUrlsModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public decimal Price { get; set; }

        public string ImageUrl { get; set; } = null!; 

        public string Description { get; set; } = null!;
    }
}
