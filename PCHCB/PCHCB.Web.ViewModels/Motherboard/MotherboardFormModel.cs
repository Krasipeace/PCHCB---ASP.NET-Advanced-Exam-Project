﻿namespace PCHCB.Web.ViewModels.Motherboard
{
    using System.ComponentModel.DataAnnotations;

    using static PCHCB.Common.EntityValidationConstants.Component;
    using static PCHCB.Common.EntityValidationConstants.Motherboard;
    using static PCHCB.Common.InputValidationDataMessages.General;
    using static PCHCB.Common.InputValidationDataMessages.Motherboard;

    /// <summary>
    /// Create/Edit Motherboard
    /// </summary>
    public class MotherboardFormModel
    {
        [Required(ErrorMessage = RequiredFieldMessage)]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = NameLengthErrorMessage)]
        [Display(Name = "Motherboard Name")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = RequiredFieldMessage)]
        [Range(typeof(decimal), PriceMinValue, PriceMaxValue, ErrorMessage = PriceRangeErrorMessage)]
        [Display(Name = "Motherboard Price")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = RequiredFieldMessage)]
        [Range(FormFactorMinValue, FormFactorMaxValue, ErrorMessage = FormFactorRangeErrorMessage)]
        [Display(Name = "Motherboard Form Factor")]
        public int FormFactor { get; set; }

        [Required(ErrorMessage = RequiredFieldMessage)]
        [StringLength(SocketMaxValue, MinimumLength = SocketMinValue, ErrorMessage = SocketLengthErrorMessage)]
        [Display(Name = "CPU Socket")]
        public string Socket { get; set; } = null!;

        [Required(ErrorMessage = RequiredFieldMessage)]
        [StringLength(ChipsetMaxValue, MinimumLength = ChipsetMinValue, ErrorMessage = ChipsetLengthErrorMessage)]
        [Display(Name = "Chipset")]
        public string Chipset { get; set; } = null!;

        [Required(ErrorMessage = RequiredFieldMessage)]
        [Range(RamTypeMinValue, RamTypeMaxValue, ErrorMessage = RamTypeRangeErrorMessage)]
        [Display(Name = "Memory Type")]
        public int RamType { get; set; }

        [Required(ErrorMessage = RequiredFieldMessage)]
        [Range(RamSlotsMinValue, RamSlotsMaxValue, ErrorMessage = RamSlotsRangeErrorMessage)]
        [Display(Name = "Available Memory Slots")]
        public int RamSlots { get; set; }

        [Required(ErrorMessage = RequiredFieldMessage)]
        [Range(RamCapacityMinValue, RamCapacityMaxValue, ErrorMessage = RamCapacityRangeErrorMessage)]
        [Display(Name = "Max Memory Capacity (GB)")]
        public int RamCapacity { get; set; }

        [Required(ErrorMessage = RequiredFieldMessage)]
        [Range(SataSlotsMinValue, SataSlotsMaxValue, ErrorMessage = SataSlotsRangeErrorMessage)]
        [Display(Name = "Available SATA Slots")]
        public int SataSlots { get; set; }

        [Required(ErrorMessage = RequiredFieldMessage)]
        [Range(PcieTypeMinValue, PcieTypeMaxValue, ErrorMessage = PcieTypeRangeErrorMessage)]
        [Display(Name = "PCI-e Type")]
        public int PcieType { get; set; } 

        [Required(ErrorMessage = RequiredFieldMessage)]
        [Range(PcieSlotsMinValue, PcieSlotsMaxValue, ErrorMessage = PcieSlotsRangeErrorMessage)]
        [Display(Name = "Available PCI-e Slots")]
        public int PcieSlots { get; set; }

        [Required(ErrorMessage = RequiredFieldMessage)]
        [Range(M2SlotsMinValue, M2SlotsMaxValue, ErrorMessage = M2SlotsRangeErrorMessage)]
        [Display(Name = "Available M.2 Slots")]
        public int M2Slots { get; set; }

        [Required(ErrorMessage = RequiredFieldMessage)]
        [Url]
        [StringLength(UrlMaxLength, MinimumLength = UrlMinLength, ErrorMessage = UrlLengthErrorMessage)]
        [Display(Name = "Image Link")]
        public string ImageUrl { get; set; } = null!;

        [Required(ErrorMessage = RequiredFieldMessage)]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength, ErrorMessage = DescriptionLengthErrorMessage)]
        [Display(Name = "Description")]
        public string Description { get; set; } = null!;
    }
}
