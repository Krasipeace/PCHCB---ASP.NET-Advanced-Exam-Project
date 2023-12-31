﻿namespace PCHCB.Web.ViewModels.Gpu
{
    using System.ComponentModel.DataAnnotations;

    using static PCHCB.Common.EntityValidationConstants.Component;
    using static PCHCB.Common.EntityValidationConstants.Gpu;
    using static PCHCB.Common.InputValidationDataMessages.General;
    using static PCHCB.Common.InputValidationDataMessages.Gpu;

    /// <summary>
    /// Create/Edit GPU
    /// </summary>
    public class GpuFormModel
    {
        [Required(ErrorMessage = RequiredFieldMessage)]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = NameLengthErrorMessage)]
        [Display(Name = "Graphic Card Name")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = RequiredFieldMessage)]
        [Range(typeof(decimal), PriceMinValue, PriceMaxValue, ErrorMessage = PriceRangeErrorMessage)]
        [Display(Name = "GPU Price")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = RequiredFieldMessage)]
        [Range(MemoryMinValue, MemoryMaxValue, ErrorMessage = MemoryRangeErrorMessage)]
        [Display(Name = "GPU Memory (in GB)")]
        public int Memory { get; set; }

        [Required(ErrorMessage = RequiredFieldMessage)]
        [Range(InterfaceMinValue, InterfaceMaxValue, ErrorMessage = InterfaceRangeErrorMessage)]
        [Display(Name = "PCI-e Type")]
        public int Interface { get; set; }

        [Required(ErrorMessage = RequiredFieldMessage)]
        [Range(typeof(double), LengthMinValue, LengthMaxValue, ErrorMessage = LengthRangeErrorMessage)]
        [Display(Name = "GPU Length (in mm)")]
        public double Length { get; set; }

        [Required(ErrorMessage = RequiredFieldMessage)]
        [Range(typeof(double), SlotsMinValue, SlotsMaxValue, ErrorMessage = SlotsRangeErrorMessage)]
        [Display(Name = "GPU Width (Slots Required)")]
        public double SlotsRequired { get; set; }

        [Required(ErrorMessage = RequiredFieldMessage)]
        [Range(PowerConsumptionMinValue, PowerConsumptionMaxValue, ErrorMessage = PowerConsumptionRangeErrorMessage)]
        [Display(Name = "Power Consumption (in Watts)")]
        public int PowerConsumption { get; set; }

        [Required(ErrorMessage = RequiredFieldMessage)]
        [Url]
        [StringLength(UrlMaxLength, MinimumLength = UrlMinLength, ErrorMessage = UrlLengthErrorMessage)]
        [Display(Name = "Image Link")]
        public string ImageUrl { get; set; } = null!;

        [Required(ErrorMessage = RequiredFieldMessage)]
        [Display(Name = "New Generation PSU Nvidia Connector")]
        public bool NvidiaConnector { get; set; }

        [Required(ErrorMessage = RequiredFieldMessage)]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength, ErrorMessage = DescriptionLengthErrorMessage)]
        [Display(Name = "Description")]
        public string Description { get; set; } = null!;
    }
}
