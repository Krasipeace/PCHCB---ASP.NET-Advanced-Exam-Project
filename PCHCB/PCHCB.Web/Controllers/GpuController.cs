﻿namespace PCHCB.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using PCHCB.Services.Data.Contracts;
    using PCHCB.Web.Infrastructure.Extensions;
    using PCHCB.Web.ViewModels.Gpu;
    using PCHCB.Web.ViewModels.Provider;
    using PCHCB.Web.ViewModels.Home;

    using static PCHCB.Common.NotificationMessages;
    using static PCHCB.Common.ErrorMessages.Provider;
    using static PCHCB.Common.ErrorMessages.Gpu;
    using static PCHCB.Common.SuccessMessages;
    using static PCHCB.Common.ExceptionMessages;

    [Authorize]
    public class GpuController : Controller
    {
        private readonly IGpuService gpuService;
        private readonly IProviderService providerService;

        public GpuController(IGpuService gpuService, IProviderService providerService)
        {
            this.gpuService = gpuService;
            this.providerService = providerService;
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            bool isProvider = await this.providerService
                .ProviderExistsByUserIdAsync(this.User.GetId()!);

            if (!isProvider)
            {
                this.TempData[ErrorMessage] = UserCannotAddGpusErrorMessage;

                return this.RedirectToAction("BecomeProvider", "Provider");
            }

            try
            {
                GpuFormModel model = new GpuFormModel();

                return this.View(model);
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(GpuFormModel model)
        {
            bool isProvider = await this.providerService
                .ProviderExistsByUserIdAsync(this.User.GetId()!);

            if (!isProvider)
            {
                this.TempData[ErrorMessage] = UserCannotAddGpusErrorMessage;

                return this.RedirectToAction("BecomeProvider", "Provider");
            }

            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            try
            {
                string? providerId = await this.providerService
                    .GetProviderByUserIdAsync(this.User.GetId()!);

                int gpuId = await this.gpuService.CreateGpuAsync(providerId!, model);

                this.TempData[SuccessMessage] = GpuAddedSuccessfully;

                return this.RedirectToAction("Add", "Gpu", new
                {
                    id = gpuId
                });
            }
            catch (Exception)
            {
                this.ModelState.AddModelError(string.Empty, GeneralErrorMessage);

                return this.View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            bool gpuExists = await gpuService
                .IsGpuExistByIdAsync(id);
            if (!gpuExists)
            {
                TempData[ErrorMessage] = GpuWithIdDoesNotExist;

                return RedirectToAction("All", "Gpu");
            }

            bool isUserProvider = await providerService
                .ProviderExistsByUserIdAsync(User.GetId()!);
            if (!isUserProvider)
            {
                TempData[ErrorMessage] = UserCannotEditGpusErrorMessage;

                return RedirectToAction("BecomeProvider", "Provider");
            }
            string? providerId = await providerService
                .GetProviderByUserIdAsync(User.GetId()!);
            bool isProviderOwner = await gpuService
                .IsProviderIdOwnerOfGpuIdAsync(providerId!, id);

            if (!isProviderOwner && !User.IsAdmin())
            {
                TempData[ErrorMessage] = ProviderCannotEditGpuHeDoesNotOwnErrorMessage;

                return RedirectToAction("Mine", "Provider");
            }

            try
            {
                GpuFormModel formModel = await gpuService
                    .GetGpuForEditByIdAsync(id);

                return View(formModel);
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, GpuFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            bool gpuExists = await gpuService
                .IsGpuExistByIdAsync(id);
            if (!gpuExists)
            {
                TempData[ErrorMessage] = GpuWithIdDoesNotExist;

                return RedirectToAction("All", "Gpu");
            }

            bool isUserProvider = await providerService
                .ProviderExistsByUserIdAsync(User.GetId()!);
            if (!isUserProvider)
            {
                TempData[ErrorMessage] = UserCannotEditGpusErrorMessage;

                return RedirectToAction("BecomeProvider", "Provider");
            }

            string? providerId = await providerService
                .GetProviderByUserIdAsync(User.GetId()!);
            bool isProviderOwner = await gpuService
                .IsProviderIdOwnerOfGpuIdAsync(providerId!, id);

            if (!isProviderOwner && !User.IsAdmin())
            {
                TempData[ErrorMessage] = ProviderCannotEditGpuHeDoesNotOwnErrorMessage;

                return RedirectToAction("Mine", "Provider");
            }

            try
            {
                await gpuService.EditGpuByIdAndFormModelAsync(id, model);
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, GeneralErrorMessage);

                return View(model);
            }

            TempData[SuccessMessage] = GpuEditedSuccessfully;

            return RedirectToAction("Edit", "Gpu", new { id });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            bool gpuExists = await gpuService
                .IsGpuExistByIdAsync(id);
            if (!gpuExists)
            {
                TempData[ErrorMessage] = GpuWithIdDoesNotExist;

                return RedirectToAction("All", "Gpu");
            }

            bool isUserProvider = await providerService
                .ProviderExistsByUserIdAsync(User.GetId()!);
            if (!isUserProvider)
            {
                TempData[ErrorMessage] = UserCannotDeleteGpusErrorMessage;

                return RedirectToAction("BecomeProvider", "Provider");
            }

            string? providerId = await providerService
                .GetProviderByUserIdAsync(User.GetId()!);
            bool isProviderOwner = await gpuService
                .IsProviderIdOwnerOfGpuIdAsync(providerId!, id);
            if (!isProviderOwner && !User.IsAdmin())
            {
                TempData[ErrorMessage] = ProviderCannotDeleteGpuHeDoesNotOwnErrorMessage;

                return RedirectToAction("Mine", "Provider");
            }

            try
            {
                DeleteDetailsViewModel viewModel = await gpuService
                    .GetGpuForDeleteByIdAsync(id);

                return View(viewModel);
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, DeleteDetailsViewModel model)
        {
            bool gpuExists = await gpuService
                .IsGpuExistByIdAsync(id);
            if (!gpuExists)
            {
                TempData[ErrorMessage] = GpuWithIdDoesNotExist;

                return RedirectToAction("All", "Gpu");
            }

            bool isUserProvider = await providerService
                .ProviderExistsByUserIdAsync(User.GetId()!);
            if (!isUserProvider)
            {
                TempData[ErrorMessage] = UserCannotDeleteGpusErrorMessage;

                return RedirectToAction("BecomeProvider", "Provider");
            }

            string? providerId = await providerService
                .GetProviderByUserIdAsync(User.GetId()!);
            bool isProviderOwner = await gpuService
                .IsProviderIdOwnerOfGpuIdAsync(providerId!, id);
            if (!isProviderOwner && !User.IsAdmin())
            {
                TempData[ErrorMessage] = ProviderCannotDeleteGpuHeDoesNotOwnErrorMessage;

                return RedirectToAction("Mine", "Provider");
            }

            try
            {
                await gpuService.DeleteGpuByIdAsync(id);

                TempData[WarningMessage] = GpuDeletedSuccessfully;

                return RedirectToAction("Mine", "Provider");
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id, string information)
        {
            bool gpuExists = await gpuService
                .IsGpuExistByIdAsync(id);
            if (!gpuExists)
            {
                TempData[ErrorMessage] = GpuWithIdDoesNotExist;

                return RedirectToAction("Mine", "Provider");
            }

            try
            {
                GpuDetailsViewModel viewModel = await gpuService
                    .GetGpuDetailsAsync(id);

                if (viewModel.GetUrlInformation() != information)
                {
                    return RedirectToAction("Error", "Home", StatusCode(404));
                }

                return View(viewModel);
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [HttpGet]
        public async Task<IActionResult> All([FromQuery] AllQueryModel queryModel)
        {
            SearchResult serviceModel = await gpuService.SearchGpusAsync(queryModel);

            queryModel.Gpus = serviceModel.Gpus;
            queryModel.TotalComponents = serviceModel.TotalComponents;

            return View(queryModel);
        }

        private IActionResult GeneralError()
        {
            this.TempData[ErrorMessage] = GeneralErrorMessage;

            return this.RedirectToAction("Index", "Home");
        }
    }
}
