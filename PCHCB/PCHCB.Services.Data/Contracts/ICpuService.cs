﻿namespace PCHCB.Services.Data.Contracts
{
    using PCHCB.Web.ViewModels.Cpu;
    using PCHCB.Web.ViewModels.Home;
    using PCHCB.Web.ViewModels.Provider;

    public interface ICpuService
    {
        Task<int> CreateCpuAsync(string providerId, CpuFormModel model);

        Task<CpuFormModel> GetCpuForEditByIdAsync(int cpuId);

        Task EditCpuByIdAndFormModelAsync(int cpuId, CpuFormModel model);

        Task<DeleteDetailsViewModel> GetCpuForDeleteByIdAsync(int id);

        Task DeleteCpuByIdAsync(int cpuId);

        Task<bool> IsCpuExistByIdAsync(int cpuId);

        Task<bool> IsProviderIdOwnerOfCpuIdAsync(string providerId, int cpuId);

        Task<IEnumerable<AllViewModel>> GetAllCpusAsync();

        Task<SearchResult> SearchCpusAsync(AllQueryModel queryModel);

        Task<CpuDetailsViewModel> GetCpuDetailsAsync(int cpuId);

        Task<IEnumerable<CpuDetailsViewModel>> GetAllCpusDetailsAsync();
    }
}
