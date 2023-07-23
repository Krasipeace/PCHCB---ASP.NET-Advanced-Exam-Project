﻿namespace PCHCB.Common
{
    public static class ErrorMessages
    {
        public static class General
        {
            public const string SomethingWentWrong = "Oops, something went wrong! Try again later or contact administrator!";
        }

        public static class Provider
        {
            public const string ProviderAlreadyExists = "You are already a provider!";

            public const string ProviderWithPhoneNumberAlreadyExists = "Provider with such Phone Number already exists!";

            public const string ProviderWithSuchLogoUrlAlreadyExists = "Provider with such Logo Image already exists!";

            public const string ProviderWithSuchWebPageAlreadyExists = "Provider with such Web Page already exists!";

            public const string UserCannotAddCasesErrorMessage = "You must be a provider to be able to add new Cases!";
            public const string UserCannotEditCasesErrorMessage = "You must be a provider to be able to edit Cases!";
            public const string ProviderCannotEditCaseHeDoesNotOwnErrorMessage = "You cannot edit a Case you do not own!";

            public const string UserCannotAddCoolersErrorMessage = "You must be a provider to be able to add new Coolers!";
            public const string UserCannotEditCoolersErrorMessage = "You must be a provider to be able to edit Coolers!";
            public const string ProviderCannotEditCoolerHeDoesNotOwnErrorMessage = "You cannot edit a Cooler you do not own!";

            public const string UserCannotAddCpusErrorMessage = "You must be a provider to be able to add new CPUs!";
            public const string UserCannotEditCpusErrorMessage = "You must be a provider to be able to edit CPUs!";
            public const string ProviderCannotEditCpuHeDoesNotOwnErrorMessage = "You cannot edit a CPU you do not own!";

            public const string UserCannotAddGpusErrorMessage = "You must be a provider to be able to add new GPUs!";
            public const string UserCannotEditGpusErrorMessage = "You must be a provider to be able to edit GPUs!";
            public const string ProviderCannotEditGpuHeDoesNotOwnErrorMessage = "You cannot edit a GPU you do not own!";

            public const string UserCannotAddMotherboardsErrorMessage = "You must be a provider to be able to add new Motherboards!";
            public const string UserCannotEditMotherboardsErrorMessage = "You must be a provider to be able to edit Motherboards!";
            public const string ProviderCannotEditMotherboardHeDoesNotOwnErrorMessage = "You cannot edit a Motherboard you do not own!";

            public const string UserCannotAddPowerSuppliesErrorMessage = "You must be a provider to be able to add new Power Supplies!";
            public const string UserCannotEditPowerSuppliesErrorMessage = "You must be a provider to be able to edit Power Supplies!";
            public const string ProviderCannotEditPowerSupplyHeDoesNotOwnErrorMessage = "You cannot edit a Power Supply you do not own!";

            public const string UserCannotAddRamsErrorMessage = "You must be a provider to be able to add new RAMs!";
            public const string UserCannotEditRamsErrorMessage = "You must be a provider to be able to edit RAMs!";
            public const string ProviderCannotEditRamHeDoesNotOwnErrorMessage = "You cannot edit a RAM you do not own!";

            public const string UserCannotAddStorageDevicesErrorMessage = "You must be a provider to be able to add new Storage Devices!";
            public const string UserCannotEditStorageDevicesErrorMessage = "You must be a provider to be able to edit Storage Devices!";
            public const string ProviderCannotEditStorageDeviceHeDoesNotOwnErrorMessage = "You cannot edit a Storage Device you do not own!";
        }

        public static class Case
        {
            public const string CaseWithIdDoesNotExist = "Case with such Id does not exist!";
        }

        public static class Cooler
        {
            public const string CoolerWithIdDoesNotExist = "Cooler with such Id does not exist!";
        }

        public static class Cpu
        {
            public const string CpuWithIdDoesNotExist = "CPU with such Id does not exist!";
        }

        public static class Gpu
        {
            public const string GpuWithIdDoesNotExist = "GPU with such Id does not exist!";
        }

        public static class Motherboard
        {
            public const string MotherboardWithIdDoesNotExist = "Motherboard with such Id does not exist!";
        }

        public static class Psu
        {
            public const string PsuWithIdDoesNotExist = "Power Supply with such Id does not exist!";
        }

        public static class Ram
        {
            public const string RamWithIdDoesNotExist = "RAM with such Id does not exist!";
        }

        public static class Storage
        {
            public const string StorageWithIdDoesNotExist = "Storage Device with such Id does not exist!";
        }
    }
}
