﻿namespace PCHCB.Services.Data
{
    using Microsoft.EntityFrameworkCore;

    using PCHCB.Data.Models;
    using PCHCB.Data.Models.Enums;
    using PCHCB.Services.Data.Contracts;
    using PCHCB.Web.Data;
    using PCHCB.Web.ViewModels.Psu;

    using static PCHCB.Common.GeneralAppConstants;

    public class PsuService : IPsuService
    {
        private readonly PCHCBDbContext dbContext;

        public PsuService(PCHCBDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<int> CreatePsuAsync(string providerId, PsuFormModel model)
        {
            Psu psu = new Psu()
            {
                Name = model.Name,
                Price = model.Price,
                Wattage = model.Wattage,
                Factor = (PsuFactor)model.Factor,
                NvidiaConnector = model.NvidiaConnector,
                ImageUrl = model.ImageUrl,
                Description = model.Description,
                AddedOn = DateTime.UtcNow,
                ProviderId = Guid.Parse(providerId),
            };

            await this.dbContext.Psus.AddAsync(psu);
            await this.dbContext.SaveChangesAsync();

            return psu.Id;
        }

        public async Task<PsuFormModel> GetPsuForEditByIdAsync(int psuId)
        {
            Psu psu = await this.dbContext.Psus
                .FirstAsync(p => p.Id == psuId);

            return new PsuFormModel
            {
                Name = psu.Name,
                Price = psu.Price,
                Wattage = psu.Wattage,
                Factor = (int)psu.Factor,
                NvidiaConnector = psu.NvidiaConnector,
                ImageUrl = psu.ImageUrl,
                Description = psu.Description
            };
        }

        public async Task EditPsuByIdAndFormModelAsync(int psuId, PsuFormModel model)
        {
            Psu psu = await this.dbContext.Psus
                .FirstAsync(p => p.Id == psuId);

            psu.Name = model.Name;
            psu.Price = model.Price;
            psu.Wattage = model.Wattage;
            psu.Factor = (PsuFactor)model.Factor;
            psu.NvidiaConnector = model.NvidiaConnector;
            psu.ImageUrl = model.ImageUrl;
            psu.Description = model.Description;

            await this.dbContext.SaveChangesAsync();
        }

        public async Task DeletePsuByIdAsync(int psuId)
        {
            Psu psu = await this.dbContext.Psus
                .FirstAsync(p => p.Id == psuId);

            psu.Name = ComponentUnavailable;
            this.dbContext.Psus.Remove(psu);

            await this.dbContext.SaveChangesAsync();
        }

        public async Task<bool> IsProviderIdOwnerOfPsuIdAsync(string providerId, int psuId)
        {
            Psu psu = await this.dbContext.Psus
                .FirstAsync(p => p.Id == psuId);

            return psu.ProviderId.ToString() == providerId;
        }

        public async Task<bool> IsPsuExistByIdAsync(int psuId)
        {
            bool result = await this.dbContext.Psus
                .AnyAsync(p => p.Id == psuId);

            return result;
        }
    }
}